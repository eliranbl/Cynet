namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantine query.
/// </summary>
public class QuarantineQuery
{
    /// <summary>
    /// Employee identifier.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// First name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; set; }

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
    /// Page number.
    /// </summary>
    public int PageNo { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    public int PageSize { get; set; }
}