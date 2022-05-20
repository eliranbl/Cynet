using Cynet.Domain.Insulations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cynet.EF.Configurations;

public class QuarantineConfiguration : IEntityTypeConfiguration<Quarantine>
{
    public void Configure(EntityTypeBuilder<Quarantine> builder)
    {
        builder.ToTable("Quarantines");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
    }
}