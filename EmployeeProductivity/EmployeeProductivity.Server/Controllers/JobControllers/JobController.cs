using Application.Common.Models.JobModels;
using Application.Jobs.Commands.CreateJob;
using Application.Jobs.Commands.DeleteJob;
using Application.Jobs.Commands.UpdateJob;
using Application.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Domain.Constants;
using EmployeeProductivity.Server.Models.JobModels;
using Application.Jobs.Commands.UpdateCommands;

namespace EmployeeProductivity.Server.Controllers.JobControllers
{
    [ApiController]
    public class JobController : BaseController
    {
        public JobController(ISender sender) : base(sender)
        {
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpGet]
        public async Task<IEnumerable<JobVM>> GetAllJobsInDepartment([FromHeader] string departmentId)
            => await _sender.Send(new GetJobsQuery { DepartmentId = Guid.Parse(departmentId) });

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpGet]
        public async Task<IActionResult> GetUserCompanyJobs()
        {
            var userName = Request.HttpContext.User.Identity;
            if (userName == null)
                return NotFound();

            var jobs = await _sender.Send(new GetUserJobsQuery { UserName = userName.Name });
            return Ok(jobs);
        }

        [Authorize(Policy = Polices.RequireDirectorOrAdminRole)]
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobRequest request)
        {
            await _sender.Send(new CreateJobCommand
            {
                Title = request.Title,
                UserName = request.UserName,
                Complexity = request.Complexity,
                MainInfo = request.MainInfo,
                Deadline = request.Deadline
            });
            return Ok();
        }

        [Authorize(Policy = Polices.RequireDirectorOrAdminRole)]
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateJob(Guid id, [AsParameters] UpdateJobCommand job)
        {
            if (id != job.Id)
                throw new NullEntityException($"{typeof(Job)}");

            await _sender.Send(job);
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpGet]
        public async Task<IList<JobVM>> GetJobsIntervalAsync([FromBody] GetJobsIntervalQuery request)
        {
            return await _sender.Send(request);
        }

        [Authorize(Policy = Polices.RequireAuthentication)]
        [HttpPatch]
        public async Task GetToWork([FromBody] UpdateJobWorkerRequest request)
        {
            await _sender.Send(new UpdateJobWorkerCommand { JobId = request.JobId, UserName = request.EmployeeName });
        }

        [Authorize(Policy = Polices.RequireDirectorOrAdminRole)]
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteJob(Guid id)
            => await _sender.Send(new DeleteJobCommand { Id = id });
    }
}
