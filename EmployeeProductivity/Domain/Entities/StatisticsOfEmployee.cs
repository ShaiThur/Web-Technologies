using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class StatisticsOfEmployee: BaseEntity
    {
        public DeliveryTimeRating? DeliveryTime { get; set; }

        public ComplexityJobsCounter? JobsComplexity { get; set; }
    }
}
