using MediatR;

namespace Application.Directors.Commands.UpdateCommands
{
    public record UpdateDirectorCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand>
    {
        public Task Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
