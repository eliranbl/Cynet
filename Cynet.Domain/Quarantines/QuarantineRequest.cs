using System.ComponentModel.DataAnnotations;

namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantine request.
/// </summary>
public class QuarantineRequest
{
    /// <summary>
    /// Email.
    /// </summary>
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email{ get; set; }

    /// <summary>
    /// From date.
    /// </summary>
    public DateTime FromDate { get; set; }
}