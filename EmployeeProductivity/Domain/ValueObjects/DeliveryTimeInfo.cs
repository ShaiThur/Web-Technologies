using Domain.Common;

namespace Domain.ValueObjects
{
    public class DeliveryTimeInfo : ValueObject
    {
        public decimal EasyJobsDeliveryTimeInfo { get; set; }

        public decimal NormalJobsDeliveryTimeInfo { get; set; }

        public decimal DifficultJobsDeliveryTimeInfo { get; set; }
    }
}