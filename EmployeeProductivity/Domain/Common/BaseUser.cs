using Domain.ValueObjects;
using System.Net.Mail;

namespace Domain.Common
{
    public class BaseUser : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public required MailAddress Email { get; set; }

        public required Password PasswordHash { get; set; }
    }
}
