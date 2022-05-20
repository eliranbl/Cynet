using Cynet.Domain.Employees;

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
    /// Date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Enter time.
    /// </summary>
    public string EnterTime { get; set; }

    /// <summary>
    /// Leave time.
    /// </summary>
    public string? LeaveTime { get; set; }

    /// <summary>
    /// Create time.
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// Employee.
    /// </summary>
    public EmployeesResponse? Employee { get; set; }
}