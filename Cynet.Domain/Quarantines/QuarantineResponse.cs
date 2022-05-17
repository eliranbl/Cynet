namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantine response.
/// </summary>
public class QuarantineResponse
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
}