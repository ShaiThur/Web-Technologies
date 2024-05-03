using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly ITokenService _tokenService;
        private readonly IApplicationDbContext _applicationDbContext;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthorizationService authorizationService,
            ITokenService tokenService,
            IApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _tokenService = tokenService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> TryAuthorizeAsync(string login, string password)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new UnauthorizedAccessException();

            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
            return result.Succeeded;
        }

        public async Task<Result> CreateUserAsync(string firstName, string lastName, string email, string password)
        {
            var user = new ApplicationUser()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = email,
                Email = email,
                PasswordHash = password,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var res = await _userManager.CreateAsync(user, password);

            return res.ToApplicationResult();
        }

        public async Task<bool> IsAuthorizedAsync(string accessToken, string refreshToken, AuthorizationPolicy policy)
        {
            var claims = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            if (claims.Identity == null || claims.Identity.Name == null)
                return false;

            var user = await _userManager.FindByNameAsync(claims.Identity.Name);
            var hasValidPolicy = await _authorizationService.AuthorizeAsync(claims, policy);

            if (user is null || user.RefreshTokenExpiry < TimeProvider.System.GetUtcNow()
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

            if (claims.Identity == null || claims.Identity.Name == null)
                return false;

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

        public async Task<IUser> FindUserAsync(string login)
        {
            var user = await _userManager.Users
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Email == login)
                ?? throw new NullEntityException(nameof(ApplicationUser));


            return user;
        }

        public async Task SaveChangesAsync(IUser user) 
            => await _userManager.UpdateAsync((ApplicationUser)user);
    }
}
