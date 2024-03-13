using Domain.Common;

namespace Domain.ValueObjects
{
    public class DeliveryTimeRating : ValueObject
    {
        public decimal EasyJobsDeliveryTimeRating { get; set; }

        public decimal NormalJobsDeliveryTimeRating { get; set; }

        public decimal DifficultJobsDeliveryTimeRating { get; set; }
    }
}