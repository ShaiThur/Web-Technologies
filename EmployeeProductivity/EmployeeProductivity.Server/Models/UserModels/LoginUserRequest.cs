namespace EmployeeProductivity.Server.Models.UserModels
{
    public record LoginUserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
