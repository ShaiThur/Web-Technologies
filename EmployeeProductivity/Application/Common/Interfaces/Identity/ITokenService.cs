using System.Security.Claims;

namespace Application.Common.Interfaces.Identity
{
    public interface ITokenService
    {
        Task<(string?, string?)> CreateTokensAsync(string login);

        Task<string?> RefreshUserTokenAsync(string login);

        Task RevokeUserRefreshTokenAsync(string login);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
