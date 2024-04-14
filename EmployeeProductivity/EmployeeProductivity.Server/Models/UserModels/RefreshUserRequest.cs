namespace EmployeeProductivity.Server.Models.UserModels
{
    public record RefreshUserRequest
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
