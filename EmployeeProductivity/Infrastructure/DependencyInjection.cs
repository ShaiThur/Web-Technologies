using Application.Common.Interfaces;
using Application.Common.Interfaces.Identity;
using Domain.Constants;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationString = configuration.GetConnectionString("DbConnection");
            
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(configurationString);
            dataSourceBuilder.MapEnum<Complexity>();
            var dataSource = dataSourceBuilder.Build();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(dataSource);
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            var secret = configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    ClockSkew = new TimeSpan(0, 0, 5)
                };
            });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();

                options.AddPolicy(Polices.CanSee, policy => policy.RequireRole(Roles.Administrator, Roles.Director, Roles.Employee));
                options.AddPolicy(Polices.CanCreate, policy => policy.RequireRole(Roles.Administrator, Roles.Director));
                options.AddPolicy(Polices.CanUpdate, policy => policy.RequireRole(Roles.Administrator, Roles.Director, Roles.Employee));
                options.AddPolicy(Polices.CanDeleteJobResults, policy => policy.RequireRole(Roles.Administrator, Roles.Employee));
                options.AddPolicy(Polices.CanDeleteJobResults, policy => policy.RequireRole(Roles.Administrator, Roles.Director));
                options.AddPolicy(Polices.CanDeleteItself, policy => policy.RequireRole(Roles.Administrator, Roles.Director, Roles.Employee));
                options.AddPolicy(Polices.CanRevokeTokens, policy => policy.RequireRole(Roles.Administrator, Roles.Director, Roles.Employee));
            });

            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddDefaultTokenProviders();

            services.AddSingleton(TimeProvider.System);

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}