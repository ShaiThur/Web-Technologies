namespace Domain.Constants
{
    public abstract class Polices
    {
        public const string CanSee = nameof(CanSee);

        public const string CanCreate = nameof(CanCreate);

        public const string CanUpdate = nameof(CanUpdate);

        public const string CanDeleteItself = nameof(CanDeleteItself);

        public const string CanRevokeTokens = nameof(CanRevokeTokens);

        public const string CanDeleteJobs = nameof(CanDeleteJobs);

        public const string CanDeleteJobResults = nameof(CanDeleteJobResults);
    }
}
