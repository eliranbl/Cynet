using Cynet.Domain.Employees;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clock.
/// </summary>
public class TimeClock : DomainBase
{
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
    /// Employee.
    /// </summary>
    public virtual Employee Employee { get; set; }
}