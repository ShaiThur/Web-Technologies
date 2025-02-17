﻿using Application.Common.Interfaces.Identity;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Middleware
{
    public class AuthorizationHandlerMiddleware : IAuthorizationMiddlewareResultHandler
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public AuthorizationHandlerMiddleware(IIdentityService identityService, ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }

        public async Task HandleAsync(RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            if (policy == null)
            {
                await next(context);
                return;
            }

            var accessToken = context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            var claims = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            if (claims.Identity != null && claims.Identity.IsAuthenticated)
            {
                context.Request.Cookies.TryGetValue("RefreshToken", out string? refreshToken);

                if (refreshToken == null || accessToken == string.Empty)
                {
                    await AddResponseToContextAsync(context, StatusCodes.Status400BadRequest);
                    await next(context);
                    return;
                }
                refreshToken = refreshToken.Replace("RefreshToken=", "");
                var isAuthorized = await _identityService.IsAuthorizedAsync(accessToken, refreshToken, policy);

                if (!isAuthorized)
                {
                    await AddResponseToContextAsync(context, StatusCodes.Status401Unauthorized);
                }
            }
            else
            {
                await AddResponseToContextAsync(context, StatusCodes.Status401Unauthorized);
            }

            await next(context);
        }

        private static async Task AddResponseToContextAsync(HttpContext context, int statusCode)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = statusCode,
            });
        }
    }
}
