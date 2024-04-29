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
    public class GetUserJobsQuery : IRequest<IEnumerable<JobVM>>
    {
        public required string UserName { get; set; }
    }

    public class GetUserJobsQueryHandler(
        IApplicationDbContext applicationDbContext,
        IIdentityService identityService,
        IMapper mapper)
        : IRequestHandler<GetUserJobsQuery, IEnumerable<JobVM>>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IIdentityService _identityService = identityService;
        private readonly IMapper _mapper = mapper;

        async Task<IEnumerable<JobVM>> IRequestHandler<GetUserJobsQuery, IEnumerable<JobVM>>.Handle(GetUserJobsQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserAsync(request.UserName)
                ?? throw new NullEntityException(request.UserName);

            var jobs = await _applicationDbContext.Jobs
                .Where(j => j.CreatorId.ToString() == user.Id || j.WorkerId.ToString() == user.Id)
                .ToListAsync(cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            var results = jobs.Select((j, JobVM) => _mapper.Map<JobVM>(j));
            return results;
        }
    }
}
