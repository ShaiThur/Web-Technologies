using Application.Common.Models;

namespace Application.Common.Interfaces.Identity
{
    public interface IRolesService
    {
        Task<Result> CreateUserRoleAsync(string role);

        Task<Result> UpdateUserRoleAsync(string login, string role);
    }
}
