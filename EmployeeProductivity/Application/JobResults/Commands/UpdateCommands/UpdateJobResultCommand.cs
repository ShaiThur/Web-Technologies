using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.JobResults.Commands.UpdateJobResult
{
    public record UpdateJobResultCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? TextResult { get; set; }
    }

    public class UpdateJobResultCommandHandler(IApplicationDbContext applicationDbContext)
        : IRequestHandler<UpdateJobResultCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task Handle(UpdateJobResultCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.JobResults
                .FindAsync([request.Id, cancellationToken], cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(JobResult));

            result.TextResult = request.TextResult;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
