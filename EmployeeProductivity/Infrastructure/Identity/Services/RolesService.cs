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

        public Task<Result> CreateUserRoleAsync(string role)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> UpdateUserRoleAsync(string login, string role)
        {
            var user = await _userManager.FindByEmailAsync(login)
                ?? throw new NullEntityException($"{nameof(ApplicationUser)} not found");

            var isExist = await _roleManager.RoleExistsAsync(role);
            if (!isExist)
            {
                throw new NullEntityException($"{nameof(Roles)} not found");
            }

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.ToApplicationResult();
        }
    }
}
