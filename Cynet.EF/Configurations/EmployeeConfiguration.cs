using Cynet.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cynet.EF.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.HasMany(x => x.TimeClocks)
            .WithOne(x => x.Employee);

        builder.HasMany(x => x.Quarantines)
            .WithOne(x => x.Employee);
    }
}