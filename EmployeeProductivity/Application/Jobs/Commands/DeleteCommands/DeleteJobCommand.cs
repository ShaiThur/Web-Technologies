using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Jobs.Commands.DeleteJob
{
    public record DeleteJobCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteJobCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<DeleteJobCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _applicationDbContext.Jobs.FindAsync(request.Id, cancellationToken)
                ?? throw new NullEntityException(nameof(Job));

            _applicationDbContext.Jobs.Remove(job);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
