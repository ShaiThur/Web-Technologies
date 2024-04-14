using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.JobConfigurations
{
    internal class JobResultConfiguration : IEntityTypeConfiguration<JobResult>
    {
        public void Configure(EntityTypeBuilder<JobResult> builder)
        {
            builder.HasKey(r => r.Id);
        }
    }
}
