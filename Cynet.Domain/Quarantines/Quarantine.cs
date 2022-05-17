using Cynet.Domain.Employees;

namespace Cynet.Domain.Insulations;

/// <summary>
/// Quarantine.
/// </summary>
public class Quarantine : DomainBase
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Employee identifier.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>   
    /// From date.
    /// </summary>
    public DateTime FromDate { get; set; }

    /// <summary>
    /// Until date.
    /// </summary>
    public DateTime UntilDate { get; set; }

    /// <summary>
    /// Sent message.
    /// </summary>
    public bool SentEmail { get; set; }

    /// <summary>
    /// Employee.
    /// </summary>
    public virtual Employee Employee { get; set; }
}