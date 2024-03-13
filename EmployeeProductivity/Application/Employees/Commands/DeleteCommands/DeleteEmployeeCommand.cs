using MediatR;

namespace Application.Employees.Commands.DeleteCommands
{
    public record DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        public Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
