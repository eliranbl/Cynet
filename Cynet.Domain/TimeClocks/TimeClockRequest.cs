namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clock request.
/// </summary>
public class TimeClockRequest
{
    /// <summary>
    /// Employee email.
    /// </summary>
    public string EmployeeEmail { get; set; }

    /// <summary>
    /// Time Clock type.
    /// </summary>
    public TimeClockType TimeClockType { get; set; }

    /// <summary>
    /// Value.
    /// </summary>
    public DateTime Value { get; set; }
}