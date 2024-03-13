using Domain.ValueObjects;
using MediatR;

namespace Application.Employees.Commands.CreateCommands
{
    public record CreateEmployeeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        public Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
