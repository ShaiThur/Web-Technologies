namespace EmployeeProductivity.Server.Models.JobModels
{
    public class UpdateJobWorkerRequest
    {
        public Guid JobId { get; set; }

        public string EmployeeName { get; set; }
    }
}