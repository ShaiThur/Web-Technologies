using Domain.Common;

namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public required string CompanyName { get; set; }

        public string? MainInfo { get; set; }
    }
}
