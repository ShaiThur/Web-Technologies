using Application.Common.Models.UsersModels;
using MediatR;

namespace Application.Directors.Commands.CreateCommands
{
    public record CreateDirectorCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }

    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, Guid>
    {
        public Task<Guid> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
