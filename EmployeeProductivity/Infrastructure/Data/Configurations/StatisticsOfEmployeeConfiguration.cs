using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class StatisticsOfEmployeeConfiguration : IEntityTypeConfiguration<StatisticsOfEmployee>
    {
        public void Configure(EntityTypeBuilder<StatisticsOfEmployee> builder)
        {
            builder.HasKey(s => s.Id);
            builder.OwnsOne(a => a.JobsComplexity);
            builder.OwnsOne(a => a.DeliveryTimeInfo);
        }
    }
}
