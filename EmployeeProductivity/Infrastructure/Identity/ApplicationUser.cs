using Application.Common.Interfaces.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiry { get; set; }

        public Department? Department { get; set; }
    }
}