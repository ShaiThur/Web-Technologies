using Application.Common.Interfaces.Identity;
using Domain.Constants;
using EmployeeProductivity.Server.Models.RoleModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Controllers.UserControllers
{
    [ApiController]
    public class RolesController : BaseController
    {
        private readonly IRolesService _rolesService;

        public RolesController(ISender sender, IRolesService rolesService) : base(sender)
        {
            _sender = sender;
            _rolesService = rolesService;
        }

        //[Authorize(Policy = Polices.RequireAdmin)]
        [HttpPut]
        public async Task AddRoleToUserAsync([FromBody] UserRolesRequest request)
        {
            await _rolesService.UpdateUserRoleAsync(request.Login, request.Role);
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpGet]
        public async Task<IActionResult> GetUserRoleAsync([FromHeader] string userLogin)
        {
            var roles = await _rolesService.GetUserRolesAsync(userLogin);

            return Ok(roles);
        }

        [Authorize(Policy = Polices.RequireAdmin)]
        [HttpDelete]
        public async Task DeleteUserRoleAsync([FromBody] UserRolesRequest request)
        {
            await _rolesService.DeleteUserRoleAsync(request.Login, request.Role);
        }
    }
}
