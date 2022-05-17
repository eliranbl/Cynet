using Microsoft.EntityFrameworkCore;

namespace Cynet.EF;

/// <summary>
/// Cynet DB context.
/// </summary>
public class CynetDbContext : DbContext
{

    /// <summary>
    /// Create context.
    /// </summary>
    /// <param name="options">Context option.</param>
    public CynetDbContext(DbContextOptions options)
        : base(options)
    {
    }
}