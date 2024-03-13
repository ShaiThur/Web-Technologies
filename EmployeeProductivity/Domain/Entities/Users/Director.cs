using Domain.Common;

namespace Domain.Entities.Users
{
    public class Director : BaseUser
    {
        public List<Employee>? Employees { get; set; }

        public List<Job>? Jobs { get; set; }

        public Company? Company { get; set; }
    }
}