namespace EmployeeProductivity.Server.Models.UserModels
{
    public record CreateUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
