using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.JobModels;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Jobs.Queries.GetJobs
{
    public record GetJobResultQuery : IRequest<JobResultVM>
    {
        public Guid Id { get; set; }
    }

    public class GetJobResultQueryHandler : IRequestHandler<GetJobResultQuery, JobResultVM>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetJobResultQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<JobResultVM> Handle(GetJobResultQuery request, CancellationToken cancellationToken)
        {
            var job = await _applicationDbContext.Jobs.FindAsync(request.Id, cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            return _mapper.Map<JobResultVM>(job.JobResult);
        }
    }
}
