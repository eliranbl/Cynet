namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Update time clock.
/// </summary>
public class UpdateTimeClock
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Enter time.
    /// </summary>
    public DateTime EnterTime { get; set; }

    /// <summary>
    /// End time.
    /// </summary>
    public DateTime? EndTime { get; set; }
}