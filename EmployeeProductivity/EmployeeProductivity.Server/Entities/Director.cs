using EmployeeProductivity.Server.Entities.Interfaces;

namespace EmployeeProductivity.Server.Entities
{
    public class Director : CompanyMember
    {
        public Company CompanyInfo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<Employee> employees { get => throw new NotImplementedException(); }
    }
}
