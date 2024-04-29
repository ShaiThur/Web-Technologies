using Domain.Common;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public required string DepartmentName { get; set; }

        public string? MainInfo { get; set; }

        public required Guid DirectorId { get; set; }

        public List<Guid>? CompanyStaffId { get; set; }
    }
}
