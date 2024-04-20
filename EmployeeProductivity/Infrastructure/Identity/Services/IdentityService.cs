using Application.Common.Exceptions;
using Application.Common.Interfaces.Identity;
using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly ITokenService _tokenService;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthorizationService authorizationService,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _tokenService = tokenService;
        }

        public async Task<bool> TryAuthorizeAsync(string login, string password)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new UnauthorizedAccessException();

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            return result.Succeeded;
        }

        public async Task<Result> CreateUserAsync(string email, string password)
        {
            var user = new ApplicationUser()
            {
                Email = email,
                UserName = email,
                PasswordHash = password,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var res = await _userManager.CreateAsync(user, password);

            return res.ToApplicationResult();
        }

        public async Task<bool> IsAuthorizedAsync(string accessToken, string refreshToken, AuthorizationPolicy policy)
        {
            var claims = _tokenService.GetPrincipalFromExpiredToken(accessToken)
                ?? throw new UnauthorizedAccessException();
            var user = await _userManager.FindByNameAsync(claims.Identity.Name);
            var hasValidPolicy = await _authorizationService.AuthorizeAsync(claims, policy);

            if (user is null || user.RefreshTokenExpiry < DateTime.UtcNow 
                || user.RefreshToken != refreshToken || !hasValidPolicy.Succeeded)
            {
                await SignOutAsync();
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(string token, string password)
        {
            var claims = _tokenService.GetPrincipalFromExpiredToken(token)
               ?? throw new UnauthorizedAccessException();

            var user = await _userManager.FindByNameAsync(claims.Identity.Name)
                ?? throw new NullEntityException($"{nameof(ApplicationUser)}");

            var canDelete = await _userManager.CheckPasswordAsync(user, password);

            if (canDelete)
            {
                await _userManager.DeleteAsync(user);
                return true;
            }

            return false;
        }

        public async Task SignOutAsync() 
            => await _signInManager.SignOutAsync();
    }
}
