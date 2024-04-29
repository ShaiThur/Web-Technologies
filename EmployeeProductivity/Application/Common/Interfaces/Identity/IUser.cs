using Domain.Entities;

namespace Application.Common.Interfaces.Identity
{
    public interface IUser
    {
        public string Id { get; }

        public string? UserName { get; }

        public Department? Department { get; set; }
    }
}
