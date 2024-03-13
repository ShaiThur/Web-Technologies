using MediatR;

namespace Application.JobResults.Commands.UpdateJobResult
{
    public record UpdateJobResultCommand : IRequest<Guid>
    {
        public Guid Guid { get; set; }
    }

    public class UpdateJobResultCommandHandler : IRequestHandler<UpdateJobResultCommand, Guid>
    {
        public Task<Guid> Handle(UpdateJobResultCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
