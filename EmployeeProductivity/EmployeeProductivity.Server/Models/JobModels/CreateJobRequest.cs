using Domain.Enums;

namespace EmployeeProductivity.Server.Models.JobModels
{
    public class CreateJobRequest
    {
        public string? Title { get; set; }

        public string? MainInfo { get; set; }

        public DateTime Deadline { get; set; }

        public Complexity Complexity { get; set; }
    }
}
