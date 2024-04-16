using Application.Common.Interfaces.Identity;
using Domain.Constants;
using EmployeeProductivity.Server.Models.RoleModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Controllers
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

        [Authorize(Policy = Polices.CanUpdate)]
        [HttpPut]
        public async Task AddRoleToUserAsync([FromBody] AddRoleToUserRequest request)
        {
            await _rolesService.UpdateUserRoleAsync(request.Login, request.Role);
        }
    }
}
