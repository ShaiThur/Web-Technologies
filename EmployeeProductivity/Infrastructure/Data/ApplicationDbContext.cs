using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<Department> Departments => Set<Department>();

        public DbSet<Job> Jobs => Set<Job>();

        public DbSet<StatisticsOfEmployee> StatisticsOfEmployees => Set<StatisticsOfEmployee>();

        public DbSet<JobResult> JobResults => Set<JobResult>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.HasPostgresEnum<Complexity>();
        }
    }
}
