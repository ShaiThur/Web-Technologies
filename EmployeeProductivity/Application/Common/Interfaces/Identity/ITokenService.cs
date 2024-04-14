namespace Application.Common.Interfaces.Identity
{
    public interface ITokenService
    {
        Task<(string?, string?)> CreateTokenAsync(string login);

        Task<(string?, string?)> RefreshUserTokenAsync(string accessToken, string refreshToken);

        Task RevokeUserRefreshTokenAsync(string login, string refreshToken);
    }
}
