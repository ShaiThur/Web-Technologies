using Application.Common.Exceptions;
using Application.Common.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<(string?, string?)> CreateTokenAsync(string login)
        {
            var accessToken = GenerateAccessToken(login);
            var user = await FindUserAsync(login);
            GenerateRefreshToken(ref user);

            return (new JwtSecurityTokenHandler().WriteToken(accessToken), user.RefreshToken);
        }

        public async Task<(string?, string?)> RefreshUserTokenAsync(string accessToken, string refreshToken)
        {
            ApplicationUser user = await FindUserAsync(accessToken, refreshToken);
            JwtSecurityToken newToken = new();

            if (user.UserName != null)
            {
                newToken = GenerateAccessToken(user.UserName);
            }          

            GenerateRefreshToken(ref user);
            await _userManager.UpdateAsync(user);

            return (new JwtSecurityTokenHandler().WriteToken(newToken), user.RefreshToken);
        }

        private async Task<ApplicationUser> FindUserAsync(string login)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new NullEntityException($"{nameof(ApplicationUser)} not found");

            return user;
        }

        private async Task<ApplicationUser> FindUserAsync(string accessToken, string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(accessToken);

            if (principal?.Identity?.Name is null)
                throw new UnauthorizedAccessException();

            var user = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
                throw new UnauthorizedAccessException();

            return user;
        }

        public async Task RevokeUserRefreshTokenAsync(string login, string refreshToken)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new UnauthorizedAccessException();

            if (user.RefreshToken == refreshToken)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

        }

        private JwtSecurityToken GenerateAccessToken(string login)
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, login),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured")));

            var expiresTimeString = _configuration["JWT:Expire"];
            int expiresTime;

            if (!int.TryParse(expiresTimeString, out expiresTime))
                throw new InvalidOperationException("Time must be number");

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddMinutes(expiresTime),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private void GenerateRefreshToken(ref ApplicationUser user)
        {
            var randomNumber = new byte[64];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);

            var expiresTimeString = _configuration["JWT:TokenValidityInMinutes"];
            int expiresTime;

            if (!int.TryParse(expiresTimeString, out expiresTime))
                throw new InvalidOperationException("Time must be number");


            user.RefreshToken = Convert.ToBase64String(randomNumber);
            user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(expiresTime);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var secret = _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");

            var validation = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:Issuer"],
                ValidAudience = _configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateLifetime = false
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
    }
}
