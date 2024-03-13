using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.UsersConfiguration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .HasMany(d => d.Employees)
                .WithOne(e => e.Director);

            builder.HasMany(d => d.Jobs)
                .WithOne(j => j.JobCreator);

            builder.HasOne(d => d.Company);

            builder.OwnsOne(d => d.Email, em =>
            {
                em.WithOwner().HasForeignKey($"{typeof(Director)}Id");
                em.Property<int>("Id");
                em.HasKey("Id");
            });
            builder.OwnsOne(d => d.PasswordHash, p =>
            {
                p.WithOwner().HasForeignKey($"{typeof(Director)}Id");
                p.Property<int>("Id");
                p.HasKey("Id");
            });
        }
    }
}
