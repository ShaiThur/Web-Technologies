namespace Application.Common.Interfaces.Authentication
{
    public interface IAuthService
    {

        Task RegisterUserAsync(string email, string password);

        //Task DeleteUserAsync(string userId);
    }
}
