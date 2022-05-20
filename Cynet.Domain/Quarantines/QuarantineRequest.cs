namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantine request.
/// </summary>
public class QuarantineRequest
{
    /// <summary>
    /// Employee identifier.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// From date.
    /// </summary>
    public DateTime FromDate { get; set; }
}