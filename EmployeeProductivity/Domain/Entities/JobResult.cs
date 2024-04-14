using Domain.Common;

namespace Domain.Entities
{
    public class JobResult : BaseEntity
    {
        public Guid JobId { get; set; }

        public Job? Job { get; set; }

        public string? TextResult { get; set; }
    }
}
