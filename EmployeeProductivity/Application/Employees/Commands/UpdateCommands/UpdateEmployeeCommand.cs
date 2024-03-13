using MediatR;

namespace Application.Employees.Commands.UpdateCommands
{
    public record UpdateEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        public Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
