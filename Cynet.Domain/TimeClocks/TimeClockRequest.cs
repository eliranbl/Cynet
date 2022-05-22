using System.ComponentModel.DataAnnotations;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clock request.
/// </summary>
public class TimeClockRequest
{
    /// <summary>
    /// Email.
    /// </summary>
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; }

    /// <summary>
    /// Time Clock type.
    /// </summary>
    public TimeClockType TimeClockType { get; set; }

    /// <summary>
    /// Value.
    /// </summary>
    public DateTime Value { get; set; }
}