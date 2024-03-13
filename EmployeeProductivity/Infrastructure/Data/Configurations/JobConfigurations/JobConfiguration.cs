using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.JobConfigurations
{
    internal class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);

            builder.HasOne(j => j.Employee)
                .WithMany(e => e.Jobs);

            builder.HasOne(j => j.JobCreator)
                .WithMany(d => d.Jobs);

            builder.HasOne(j => j.JobResult);

            builder.Property(p => p.Deadline)
                .HasConversion<DateTime>();

            builder.Property(p => p.DeliveryTime)
                .HasConversion<DateTime>();
        }
    }
}
