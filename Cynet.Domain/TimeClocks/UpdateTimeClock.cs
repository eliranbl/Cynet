namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Update time clock.
/// </summary>
public class UpdateTimeClock
{
    /// <summary>
    /// Enter time.
    /// </summary>
    public string EnterTime { get; set; }

    /// <summary>
    /// Leave time.
    /// </summary>
    public string? LeaveTime { get; set; }
}