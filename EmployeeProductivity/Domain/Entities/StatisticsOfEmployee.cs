using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class StatisticsOfEmployee : BaseEntity
    {
        public DeliveryTimeInfo? DeliveryTimeInfo { get; set; }

        public JobsComplexityKeeper? JobsComplexity { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
