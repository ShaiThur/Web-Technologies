using MediatR;

namespace Application.Directors.Commands.DeleteCommands
{
    public record DeleteDirectorCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
    {
        public Task Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
