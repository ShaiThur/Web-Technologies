using Domain.Common;
using Domain.Entities.Users;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Job : BaseEntity
    {
        public required string Title { get; set; } 

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public Complexity Complexity { get; set; }

        public Employee? Employee { get; set; }

        public required Director JobCreator { get; set; }

        public JobResult? JobResult { get; set; }

        public bool IsFinished { get; set; }
    }
}
