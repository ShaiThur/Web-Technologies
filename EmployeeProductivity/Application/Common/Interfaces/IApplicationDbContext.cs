using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Department> Departments { get; }

        DbSet<Job> Jobs { get; }

        DbSet<StatisticsOfEmployee> StatisticsOfEmployees { get; }

        public DbSet<JobResult> JobResults { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
