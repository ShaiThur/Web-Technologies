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
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EmployeeProductivity.Server.Controllers
{
    [ApiController]
    public class JobController : BaseController
    {
        public JobController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<JobVM> GetJob(Guid id) 
            => await _sender.Send(new GetJobQuery { Id = id });


        [HttpPost]
        public async Task<Guid> CreateJob([AsParameters] CreateJobCommand job) 
            => await _sender.Send(job);

        [HttpPut]
        [Route("{id}")]
        public async Task UpdateJob(Guid id, [AsParameters] UpdateJobCommand job)
        {
            if (id != job.Id)
                throw new NullEntityException($"{typeof(Job)}");

            await _sender.Send(job);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteJob(Guid id) 
            => await _sender.Send(new DeleteJobCommand{ Id = id});
    }
}
