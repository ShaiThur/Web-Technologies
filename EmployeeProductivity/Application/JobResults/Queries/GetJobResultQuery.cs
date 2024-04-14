using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.JobModels;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.JobResults.Queries
{
    public record GetJobResultQuery : IRequest<JobResultVM>
    {
        public Guid JobId { get; set; }
    }

    public class GetJobResultQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        : IRequestHandler<GetJobResultQuery, JobResultVM>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<JobResultVM> Handle(GetJobResultQuery request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.JobResults
                .Where(j => j.JobId == request.JobId)
                .FirstOrDefaultAsync()
               ?? throw new NullEntityException(nameof(JobResult));

            return _mapper.Map<JobResultVM>(result);
        }
    }
}
