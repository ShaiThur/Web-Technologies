using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.UsersConfiguration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Directors);
            builder.HasMany(a => a.Employees);

            builder.OwnsOne(a => a.Email, em =>
            {
                em.WithOwner().HasForeignKey($"{typeof(Admin)}Id");
                em.Property<int>("Id");
                em.HasKey("Id");
            });
            builder.OwnsOne(a => a.PasswordHash, p =>
            {
                p.WithOwner().HasForeignKey($"{typeof(Admin)}Id");
                p.Property<int>("Id");
                p.HasKey("Id");
            });
        }
    }
}
