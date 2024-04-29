using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.JobResults.Commands.CreateJobResult
{
    public record CreateJobResultCommand : IRequest<Guid>
    {
        public Guid JobId;

        public string? TextResult { get; set; }
    }

    public class CreateJobResultCommandHandler(IApplicationDbContext applicationDbContext)
        : IRequestHandler<CreateJobResultCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<Guid> Handle(CreateJobResultCommand request, CancellationToken cancellationToken)
        {
            var jobResult = new JobResult
            {
                Id = Guid.NewGuid(),
                TextResult = request.TextResult
            };

            await _applicationDbContext.JobResults.AddAsync(jobResult, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return jobResult.Id;
        }
    }
}
