namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clock response.
/// </summary>
public class TimeClockResponse
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
    /// Day.
    /// </summary>
    public string Day { get; set; }

    /// <summary>
    /// Week.
    /// </summary>
    public int Week { get; set; }

    /// <summary>
    /// Date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Enter time.
    /// </summary>
    public DateTime EnterTime { get; set; }

    /// <summary>
    /// End time.
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// Create time.
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}