using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Models.UsersModels
{
    public partial class BaseUserVM
    {

        protected string? _emailAddress;
        protected string? _password;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string EmailAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_emailAddress) || !LoginRegex().IsMatch(_emailAddress))
                    throw new ValidationException("incorrect email");

                return _emailAddress;
            }

            set
            {
                _emailAddress = value;
            }
        }

        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(_password) || !PasswordRegex().IsMatch(_password))
                    throw new ValidationException();

                return _password;
            }
            set
            {
                _password = value;
            }
        }

        [GeneratedRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        private static partial Regex LoginRegex();

        [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        private static partial Regex PasswordRegex();
    }
}
