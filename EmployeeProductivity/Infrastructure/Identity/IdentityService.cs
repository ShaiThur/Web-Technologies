using Application.Common.Interfaces.Authentication;

namespace Infrastructure.Identity
{
    internal class IdentityService(IPasswordHasher passwordHasher) : IAuthService
    {
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task RegisterUserAsync(string email, string password)
        {
            _ = _passwordHasher.GenerateHash(password);
            return;
        }
    }
}
