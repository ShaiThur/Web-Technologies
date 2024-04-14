using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; }

        DbSet<Job> Jobs { get; }

        DbSet<Statistics> StatisticsOfEmployees { get; }

        public DbSet<JobResult> JobResults { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
