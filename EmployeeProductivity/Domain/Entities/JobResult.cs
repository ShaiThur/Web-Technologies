using Domain.Common;

namespace Domain.ValueObjects
{
    public class JobResult : BaseEntity
    {
        public required string TextResult { get; set; }
    }
}
