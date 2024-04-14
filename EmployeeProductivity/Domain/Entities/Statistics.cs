using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Statistics : BaseEntity
    {
        public DeliveryTimeInfo? DeliveryTimeInfo { get; set; }

        public JobsComplexityKeeper? JobsComplexity { get; set; }
    }
}
