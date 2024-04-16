using EmployeeProductivity.Server.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServerServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                });
            });
            //services.AddScoped<IUser, CurrentUser>();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Jwt", new OpenApi.Models.OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
            });
            services.AddExceptionHandler<CustomExceptionsHandlerMiddleware>();
            services.AddSingleton<IAuthorizationService, DefaultAuthorizationService>();
            return services;
        }
    }
}
