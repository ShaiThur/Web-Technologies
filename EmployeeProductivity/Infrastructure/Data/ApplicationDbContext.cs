using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Company> Companies => Set<Company>();

        public DbSet<Job> Jobs => Set<Job>();

        public DbSet<StatisticsOfEmployee> EmployeeStatisticsList => Set<StatisticsOfEmployee>();

        public DbSet<Admin> Admins => Set<Admin>();

        public DbSet<Director> Directors => Set<Director>();

        public DbSet<Employee> Employees => Set<Employee>();

        public new async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }
}
