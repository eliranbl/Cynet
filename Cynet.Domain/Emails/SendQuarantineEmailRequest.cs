namespace Cynet.Domain.Emails;

/// <summary>
/// Send email request.
/// </summary>
public class SendQuarantineEmailRequest
{
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
}