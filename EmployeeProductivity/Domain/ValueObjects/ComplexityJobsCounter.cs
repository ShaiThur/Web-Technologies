using Domain.Common;

namespace Domain.ValueObjects
{
    public class ComplexityJobsCounter(int easyJobs, int normalJobs, int difficultJobs) : ValueObject
    {
        public int EasyJobsCount { get; } = easyJobs;

        public int NormalJobsCount { get; } = normalJobs;

        public int DifficultJobsCount { get; } = difficultJobs;

        public int AllJobs = easyJobs + normalJobs + difficultJobs;
    }
}