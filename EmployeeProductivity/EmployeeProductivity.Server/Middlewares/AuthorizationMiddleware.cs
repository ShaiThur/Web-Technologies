using Application.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeProductivity.Server.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthorizationService authorizationService)
        {
            var endpoint = context.GetEndpoint();

            if (endpoint != null)
            {
                var authorizeAttribute = endpoint.Metadata.GetMetadata<AuthorizeAttribute>();
                if (authorizeAttribute != null && authorizeAttribute.Policy != null)
                {
                    foreach (var policy in authorizeAttribute.Policy)
                    {
                        //var authorized = await _identityService.IsInPolicyAsync(_user.Id, policy);

                        if (!false)
                        {
                            throw new ForbiddenAccessException();
                        }
                    }

                    var roles = authorizeAttribute.Roles;
                }
            }

            await _next(context);
        }
    }

    public static class AuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
