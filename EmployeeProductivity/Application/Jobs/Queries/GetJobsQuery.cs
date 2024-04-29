using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Application.Common.Models.JobModels;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Jobs.Queries
{
    public record GetJobsQuery : IRequest<IEnumerable<JobVM>>
    {     
        public Guid DepartmentId { get; set; }
    }

    public class GetJobsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IIdentityService identityService)
        : IRequestHandler<GetJobsQuery, IEnumerable<JobVM>>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<JobVM>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _applicationDbContext.Jobs
                .Where(j => j.Department != null && j.Department.Id == request.DepartmentId)
                .ToListAsync(cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            var results = jobs.Select((j, JobVM) => _mapper.Map<JobVM>(j));
            return results;
        }
    }
}
