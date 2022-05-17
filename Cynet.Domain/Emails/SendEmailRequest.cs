namespace Cynet.Domain.Emails;

/// <summary>
/// Send email request.
/// </summary>
public class SendEmailRequest
{
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
}