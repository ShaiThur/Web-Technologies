namespace Domain.Constants
{
    public abstract class Polices
    {
        public const string RequireAuthentication = nameof(RequireAuthentication);

        public const string RequireDirectorOrAdminRole = nameof(RequireDirectorOrAdminRole);

        public const string RequireAdmin = nameof(RequireAdmin);
    }
}
