using Application.Common.Models;
using System.Security.Claims;

namespace Application.Common.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<Result> CreateUserAsync(string email, string password);

        Task<bool> AuthorizeAsync(string login, string password);

        Task<bool> IsInRoleAsync(string login, string role);

        Task<bool> IsAuthenticatedAsync(string accessToken, string policy);

        Task DeleteUserAsync(string email, string password);

        Task SignOutAsync();
    }
}