using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class StatisticsConfiguration : IEntityTypeConfiguration<StatisticsOfEmployee>
    {
        public void Configure(EntityTypeBuilder<StatisticsOfEmployee> builder)
        {
            builder.HasKey(s => s.Id);

            builder.OwnsOne(a => a.JobsComplexity, p =>
            {
                p.WithOwner().HasForeignKey($"{typeof(StatisticsOfEmployee)}Id");
                p.Property<int>("Id");
                p.HasKey("Id");
            });
        }
    }
}
