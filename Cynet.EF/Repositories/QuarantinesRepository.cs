using Cynet.Domain.Insulations;
using Cynet.Domain.Quarantines;

namespace Cynet.EF.Repositories;

public class QuarantinesRepository : IQuarantinesRepository
{
    private readonly CynetDbContext _context;

    /// <summary>
    /// Create repository.
    /// </summary>
    /// <param name="context"></param>
    public QuarantinesRepository(CynetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Add quarantine range.
    /// </summary>
    /// <param name="quarantines">Quarantines.</param>
    public async Task AddQuarantineRangeAsync(List<Quarantine> quarantines)
    {
        await _context.Quarantines.AddRangeAsync(quarantines);

        await _context.SaveChangesAsync();
    }
}