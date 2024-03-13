using Domain.Common;

namespace Domain.Entities.Users
{
    public class Employee: BaseUser
    {
        public List<Job>? Jobs { get; set; }

        public StatisticsOfEmployee? Statistics { get; set; } 

        public Company? Company { get; set; } 

        public Director? Director { get; set; } 
    }
}
