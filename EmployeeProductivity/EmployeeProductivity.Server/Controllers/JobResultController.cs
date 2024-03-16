using Application.Common.Exceptions;
using Application.Common.Models.JobModels;
using Application.JobResults.Commands.CreateJobResult;
using Application.JobResults.Commands.DeleteJobResult;
using Application.JobResults.Commands.UpdateJobResult;
using Application.JobResults.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Controllers
{
    public class JobResultController : BaseController
    {
        public JobResultController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<JobResultVM> GetJobResult(Guid id) 
            => await _sender.Send(new GetJobResultQuery { Id = id });

        [HttpPost]
        public async Task<Guid> CreateJobResult([AsParameters] CreateJobResultCommand jobResult) 
            => await _sender.Send(jobResult);

        [HttpPut]
        [Route("{id}")]
        public async Task UpdateJobResult(Guid id, [AsParameters] UpdateJobResultCommand jobResult)
        {
            if (id != jobResult.Id)
                throw new NullEntityException($"{typeof(Job)}");

            await _sender.Send(jobResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteJobResult(Guid id)
            => await _sender.Send(new DeleteJobResultCommand { Id = id });
    }
}
