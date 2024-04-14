using MediatR;

namespace Application.StatisticsOfEmployees.Commands.DeleteCommands
{
    public record DeleteStatisticsOfEmployeesCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
