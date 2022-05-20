namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantines service.
/// </summary>
public interface IQuarantinesService
{
    /// <summary>
    /// Declare positive.
    /// </summary>
    /// <param name="request">Quarantine request.</param>
    Task DeclarePositiveAsync(QuarantineRequest request);
}