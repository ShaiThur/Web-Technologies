using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.Users;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; }

        DbSet<Job> Jobs { get; }

        DbSet<StatisticsOfEmployee> EmployeeStatisticsList { get; }

        DbSet<Admin> Admins { get; }

        DbSet<Director> Directors { get; }

        DbSet<Employee> Employees { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
