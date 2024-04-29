namespace EmployeeProductivity.Server.Models.RoleModels
{
    public record UserRolesRequest
    {
        public required string Login { get; set; }

        public required string Role { get; set; }
    }
}
