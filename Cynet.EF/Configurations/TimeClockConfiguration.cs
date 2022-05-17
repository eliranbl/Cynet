using Cynet.Domain.TimeClocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cynet.EF.Configurations;

public class TimeClockConfiguration : IEntityTypeConfiguration<TimeClock>
{
    public void Configure(EntityTypeBuilder<TimeClock> builder)
    {
        builder.ToTable("TimeClocks");

        builder.HasIndex(x => new { x.Date, x.EmployeeId }).IsUnique();
    }
}