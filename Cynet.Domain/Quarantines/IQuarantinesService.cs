using Cynet.Common.Paging;

namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantines service.
/// </summary>
public interface IQuarantinesService
{
    /// <summary>
    /// Add quarantine range.
    /// </summary>
    /// <param name="quarantines">Quarantine.</param>
    /// <returns>Identifiers.</returns>
    Task<List<Guid>> AddQuarantineRangeAsync(List<QuarantineRequest> quarantines);

    /// <summary>
    /// Add quarantine.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<Guid> AddQuarantineAsync(QuarantineRequest request);

    /// <summary>
    /// Get Quarantines.
    /// </summary>
    /// <param name="query">Quarantine query.</param>
    /// <returns>Quarantine response page.</returns>
    Task<Page<QuarantineResponse>> GetQuarantinesAsync(QuarantineQuery query);
}