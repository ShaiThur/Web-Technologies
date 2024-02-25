using EmployeeProductivity.Server.Entities.Interfaces;

namespace EmployeeProductivity.Server.Entities
{
    public class Employee : CompanyMember
    {
        Statistic Stats { get; set; }
        public Company CompanyInfo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
