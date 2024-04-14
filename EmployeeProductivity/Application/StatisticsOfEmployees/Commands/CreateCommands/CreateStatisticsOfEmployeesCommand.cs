using Domain.ValueObjects;
using MediatR;

namespace Application.StatisticsOfEmployees.Commands.CreateCommands
{
    public record DeleteStatisticsOfEmployeesCommand : IRequest<Guid>
    {
        public DeliveryTimeInfo? DeliveryTimeInfo { get; set; }

        public JobsComplexityKeeper? JobsComplexity { get; set; }
    }
}
