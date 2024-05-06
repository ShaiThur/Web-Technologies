using Application.Common.Interfaces.Identity;
using Application.Common.Interfaces;
using Application.Common.Models.JobModels;
using AutoMapper;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Jobs.Queries
{
    public record GetJobsIntervalQuery : IRequest<IList<JobVM>>
    {
        public Guid DepartmentId { internal get; set; }

        public int NumberInterval { internal get; set; }
    }

    internal class GetJobsIntervalQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IIdentityService identityService)
        : IRequestHandler<GetJobsIntervalQuery, IList<JobVM>>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;
        private readonly IMapper _mapper = mapper;

        public async Task<IList<JobVM>> Handle(GetJobsIntervalQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _applicationDbContext.Jobs
                .Where(j => j.Department != null && j.Department.Id == request.DepartmentId)
                .ToListAsync(cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            var results = jobs.Select((j, JobVM) => _mapper.Map<JobVM>(j)).ToList();
            var interval = 7;
            var baseInterval = 7;
            interval *= request.NumberInterval;

            if (interval > results.Count())
                throw new InvalidOperationException();

            return results[(interval - baseInterval)..(interval-1)];
        }
    }
}
