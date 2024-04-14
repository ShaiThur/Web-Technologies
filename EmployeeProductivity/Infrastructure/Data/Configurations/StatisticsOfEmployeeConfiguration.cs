using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class StatisticsOfEmployeeConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            builder.HasKey(s => s.Id);

            builder.OwnsOne(a => a.JobsComplexity);
            builder.OwnsOne(a => a.DeliveryTimeInfo);
        }
    }
}
