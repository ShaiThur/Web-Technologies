using EmployeeProductivity.Server.Entities;

public interface CompanyMember : User
{
    public Company CompanyInfo { get; set; }
}

