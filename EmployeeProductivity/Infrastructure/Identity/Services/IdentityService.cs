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
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }

        public async Task<bool> AuthorizeAsync(string login, string password)
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

        public async Task<bool> IsInRoleAsync(string login, string role)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new UnauthorizedAccessException();

            var inRole = await _userManager.IsInRoleAsync(user, role);

            if (inRole)
                return true;

            return false;
        }

        public async Task<bool> IsInPolicyAsync(string login, string policy)
        {
            var user = await _userManager.FindByIdAsync(login);

            if (user == null)
                throw new NullEntityException($"{nameof(ApplicationUser)} not found");

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
            var result = await _authorizationService.AuthorizeAsync(principal, policy);

            return result.Succeeded;
        }

        public async Task DeleteUserAsync(string login, string password)
        {
            var user = await _userManager.FindByEmailAsync(login)
                   ?? throw new NullEntityException($"{nameof(ApplicationUser)} not found");

            if (await _userManager.CheckPasswordAsync(user, password))
                await _userManager.DeleteAsync(user);
            else
                throw new UnauthorizedAccessException();
        }
    }
}
