using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.JobResults.Commands.DeleteJobResult
{
    public record DeleteJobResultCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteJobResultCommandHandler(IApplicationDbContext applicationDbContext)
        : IRequestHandler<DeleteJobResultCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task Handle(DeleteJobResultCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.JobResults
                .FindAsync([request.Id, cancellationToken], cancellationToken: cancellationToken)
                ?? throw new NullEntityException(nameof(JobResult));

            _applicationDbContext.JobResults.Remove(result);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
