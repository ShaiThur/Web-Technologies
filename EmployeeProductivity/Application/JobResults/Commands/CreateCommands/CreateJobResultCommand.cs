using MediatR;

namespace Application.JobResults.Commands.CreateJobResult
{
    public record CreateJobResultCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class CreateJobResultCommandHandler : IRequestHandler<CreateJobResultCommand>
    {
        public Task Handle(CreateJobResultCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
