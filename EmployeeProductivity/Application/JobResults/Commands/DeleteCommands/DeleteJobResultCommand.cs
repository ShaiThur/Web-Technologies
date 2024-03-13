using MediatR;

namespace Application.JobResults.Commands.DeleteJobResult
{
    public record DeleteJobResultCommand : IRequest
    {
    }

    public class DeleteJobResultCommandHandler : IRequestHandler<DeleteJobResultCommand>
    {
        public Task Handle(DeleteJobResultCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
