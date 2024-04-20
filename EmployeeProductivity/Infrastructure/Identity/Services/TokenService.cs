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

        public async Task<(string?, string?)> CreateTokensAsync(string login)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new NullEntityException($"{nameof(ApplicationUser)}");
            var userRole = await _userManager.GetRolesAsync(user);
            var accessToken = GenerateAccessToken(login, userRole);
            GenerateRefreshToken(ref user);
            await _userManager.UpdateAsync(user);

            return (new JwtSecurityTokenHandler().WriteToken(accessToken), user.RefreshToken);
        }

        public async Task<string?> RefreshUserTokenAsync(string login)
        {

            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new UnauthorizedAccessException();
            var userRoles = await _userManager.GetRolesAsync(user);

            JwtSecurityToken newToken = GenerateAccessToken(login, userRoles);      

            return new JwtSecurityTokenHandler().WriteToken(newToken);
        }

        public async Task RevokeUserRefreshTokenAsync(string login)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new UnauthorizedAccessException();

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }

        private JwtSecurityToken GenerateAccessToken(string login, IList<string> roles)
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, login),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
                authClaims.Add(new(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured")));

            var expiresTimeString = _configuration["JWT:AccessTokenExpireInMinutes"];
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

            var expiresTimeString = _configuration["JWT:RefreshTokenExpireInDays"];
            int expiresTime;

            if (!int.TryParse(expiresTimeString, out expiresTime))
                throw new InvalidOperationException("Time must be number");

            user.RefreshToken = Convert.ToBase64String(randomNumber);
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(expiresTime);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
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
