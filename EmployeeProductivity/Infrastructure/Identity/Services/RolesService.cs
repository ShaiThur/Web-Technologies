using Application.Common.Exceptions;
using Application.Common.Interfaces.Identity;
using Application.Common.Models;
using Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services
{
    public class RolesService : IRolesService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<Result> CreateUserRoleAsync(string role)
        {
            IdentityResult result = new();
            if (!(await _roleManager.RoleExistsAsync(role)))
                result = await _roleManager.CreateAsync(new(role));

            return ResultExtensions.ToApplicationResult(result);
        }

        public async Task<Result> UpdateUserRoleAsync(string login, string role)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new NullEntityException($"{nameof(ApplicationUser)} not found");

            var isExist = await _roleManager.RoleExistsAsync(role);
            if (!isExist)
            {
                throw new NullEntityException($"{nameof(Roles)} not found");
                //await CreateUserRoleAsync(role);
            }

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.ToApplicationResult();
        }

        public async Task<Result> DeleteUserRoleAsync(string login, string role)
        {
            var user = await _userManager.FindByEmailAsync(login)
               ?? throw new NullEntityException($"{nameof(ApplicationUser)} not found");

            var result = await _userManager.RemoveFromRoleAsync(user, role);

            return result.ToApplicationResult();
        }

        public async Task<IList<string>> GetUserRolesAsync(string login)
        {
            var user = await _userManager.FindByEmailAsync(login)
               ?? throw new NullEntityException($"{nameof(ApplicationUser)} not found");

            var roles = await _userManager.GetRolesAsync(user)
                ?? throw new NullEntityException(nameof(IdentityRole));

            return roles;
        }
    }
}
