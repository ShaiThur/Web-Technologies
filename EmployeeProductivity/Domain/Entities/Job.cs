using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Job : BaseEntity
    {
        public string? Title { get; set; } 

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public Complexity Complexity { get; set; }

        public bool IsFinished { get; set; }

        public Guid CreatorId { get; set; }

        public Guid? WorkerId { get; set; }

        public JobResult? JobResult { get; set; }

        public Department? Department { get; set; }
    }
}
