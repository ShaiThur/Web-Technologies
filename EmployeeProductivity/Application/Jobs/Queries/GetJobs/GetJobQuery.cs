using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.JobModels;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Jobs.Queries.GetJobs
{
    public record GetJobQuery : IRequest<JobVM>
    {
        public Guid Id { get; set; }
    }

    public class GetJobQueryHandler : IRequestHandler<GetJobQuery, JobVM>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetJobQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<JobVM> Handle(GetJobQuery request, CancellationToken cancellationToken)
        {
            var job = await _applicationDbContext.Jobs.FindAsync(request.Id, cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            return _mapper.Map<JobVM>(job);
        }
    }
}
