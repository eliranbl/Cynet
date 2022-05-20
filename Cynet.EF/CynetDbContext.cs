using Cynet.Domain.Employees;
using Cynet.Domain.Insulations;
using Cynet.Domain.TimeClocks;
using Microsoft.EntityFrameworkCore;

namespace Cynet.EF;

/// <summary>
/// Cynet DB context.
/// </summary>
public class CynetDbContext : DbContext
{
    /// <summary>
    /// Quarantines.
    /// </summary>
    public DbSet<Quarantine> Quarantines { get; set; }

    /// <summary>
    /// TimeClocks.
    /// </summary>
    public DbSet<TimeClock> TimeClocks { get; set; }

    /// <summary>
    /// Employees.
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Create context.
    /// </summary>
    /// <param name="options">Context option.</param>
    public CynetDbContext(DbContextOptions options)
        : base(options)
    {
    }
}