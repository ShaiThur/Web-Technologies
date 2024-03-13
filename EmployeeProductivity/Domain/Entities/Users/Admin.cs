using Domain.Common;

namespace Domain.Entities.Users
{
    public class Admin : BaseUser
    {
        public List<Employee>? Employees { get; set; }

        public List<Director>? Directors { get; set; }
    }
}
