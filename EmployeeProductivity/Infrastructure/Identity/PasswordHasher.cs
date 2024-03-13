using Application.Common.Interfaces.Authentication;

namespace Infrastructure.Identity
{
    internal class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool IsVerified(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(inputPassword, hashedPassword);
        }
    }
}
