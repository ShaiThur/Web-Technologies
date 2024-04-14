namespace EmployeeProductivity.Server.Models.UserModels
{
    public record RevokeUserRequest
    {
        public required string Login { get; set; }

        public required string RefreshToken { get; set; }
    }
}
