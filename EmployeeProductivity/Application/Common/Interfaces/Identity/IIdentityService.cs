using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace Application.Common.Interfaces.Identity
{
    public interface IIdentityService
    {

        Task<IUser> FindUserAsync(string login);

        Task SaveChangesAsync(IUser user);

        Task<Result> CreateUserAsync(string firstName, string lastName, string email, string password);

        Task<bool> TryAuthorizeAsync(string login, string password);

        Task<bool> IsAuthorizedAsync(string accessToken, string refreshToken, AuthorizationPolicy policy);

        Task<bool> DeleteUserAsync(string email, string password);

        Task SignOutAsync();
    }
}