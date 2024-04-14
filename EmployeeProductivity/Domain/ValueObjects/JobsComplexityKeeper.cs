using Domain.Common;

namespace Domain.ValueObjects
{
    public class JobsComplexityKeeper : ValueObject
    {
        public int EasyJobsCount { get; set; }

        public int NormalJobsCount { get; set; }

        public int DifficultJobsCount { get; set; }
    }
}