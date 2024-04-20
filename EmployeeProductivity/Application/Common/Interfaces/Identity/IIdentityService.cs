﻿using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace Application.Common.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<Result> CreateUserAsync(string email, string password);

        Task<bool> TryAuthorizeAsync(string login, string password);

        Task<bool> IsAuthorizedAsync(string accessToken, string refreshToken, AuthorizationPolicy policy);

        Task<bool> DeleteUserAsync(string email, string password);

        Task SignOutAsync();
    }
}