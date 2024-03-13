namespace Application.Common.Interfaces.Authentication
{
    public interface IPasswordHasher
    {
        string GenerateHash(string password);

        bool IsVerified(string inputPassword, string hashedPassword);
    }
}
