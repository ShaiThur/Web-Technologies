using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models.JobModels;
using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Jobs.Queries
{
    public record GetJobQuery : IRequest<JobVM>
    {
        public Guid Id { get; set; }
    }

    public class GetJobQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        : IRequestHandler<GetJobQuery, JobVM>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<JobVM> Handle(GetJobQuery request, CancellationToken cancellationToken)
        {
            var job = await _applicationDbContext.Jobs.FindAsync([request.Id, cancellationToken], cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            return _mapper.Map<JobVM>(job);
        }
    }
}
