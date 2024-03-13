using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.UsersConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(e => e.Director)
                .WithMany(d => d.Employees);
            builder.HasOne(d => d.Company);

            builder.HasMany(e => e.Jobs)
                .WithOne(j => j.Employee);

            builder.OwnsOne(e => e.Email, em =>
            {
                em.WithOwner().HasForeignKey($"{typeof(Employee)}Id");
                em.Property<int>("Id");
                em.HasKey("Id");
            });
            builder.OwnsOne(e => e.PasswordHash, p =>
            {
                p.WithOwner().HasForeignKey($"{typeof(Employee)}Id");
                p.Property<int>("Id");
                p.HasKey("Id");
            });
        }
    }
}
