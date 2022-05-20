using Cynet.Domain.Insulations;

namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantines repository.
/// </summary>
public interface IQuarantinesRepository
{
    /// <summary>
    /// Add quarantine range.
    /// </summary>
    /// <param name="quarantines">Quarantines.</param>
    public Task AddQuarantineRangeAsync(List<Quarantine> quarantines);
}