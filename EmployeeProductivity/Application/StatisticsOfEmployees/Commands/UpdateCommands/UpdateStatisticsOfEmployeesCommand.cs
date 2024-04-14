using Domain.ValueObjects;
using MediatR;

namespace Application.StatisticsOfEmployees.Commands.UpdateCommands
{
    public record UpdateStatisticsOfEmployeesCommand : IRequest
    {
        public DeliveryTimeInfo? DeliveryTimeInfo { get; set; }

        public JobsComplexityKeeper? JobsComplexity { get; set; }
    }
}
