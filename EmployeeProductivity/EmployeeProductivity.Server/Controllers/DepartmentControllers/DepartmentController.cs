using Application.Companies.Commands.CreateCommands;
using Application.Companies.Commands.DeleteCommands;
using Application.Companies.Queries;
using Application.Departments.Commands.UpdateCommands;
using Domain.Constants;
using EmployeeProductivity.Server.Models.DepartmentModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Controllers.DepartmentControllers
{
    [ApiController]
    public class DepartmentController : BaseController
    {
        public DepartmentController(ISender sender) : base(sender)
        {
        }

        [Authorize(Policy = Polices.RequireAdmin)]
        [HttpPost]
        public async Task<IActionResult> CreateNewDepartment([FromBody] CreateDepartmentRequest request)
        {
            var userName = Request.HttpContext.User.Identity;
            if (userName == null)
                return NotFound();

            await _sender.Send(new CreateDepartmentCommand
            {
                DirectorName = userName.Name,
                DepartmentName = request.DepartmentName
            });

            return Ok();
        }

        [Authorize(Policy = Polices.RequireAdmin)]
        [HttpPatch]
        public async Task<IActionResult> AddNewUserInDepartmentAsync([FromBody] UpdateDepartmentRequest request)
        {
            var userName = Request.HttpContext.User.Identity;
            if (userName == null)
                return NotFound();

            await _sender.Send(new UpdateDepartmentStaffCommand
            {
                DirectorName = userName.Name,
                NewEmployeeLogin = request.EmployeeLogin
            });
            return Ok();
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpGet]
        public async Task<IActionResult> GetDepartment([FromHeader] string userName)
        {
            var department = await _sender.Send(new GetDepartmentQuery { UserName = userName });
            return Ok(department);
        }

        [Authorize(Policy = Polices.RequireAdmin)]
        [HttpDelete]
        public async Task DeleteDepartmentAsnyc([FromBody] DeleteDeartmentRequest request)
        {
            await _sender.Send(new DeleteDepartmentCommand { DepartmentId = request.DepartmentId });
        }
    }
}
