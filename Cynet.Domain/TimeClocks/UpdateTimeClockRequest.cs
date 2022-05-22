using System.ComponentModel.DataAnnotations;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Update time clock request.
/// </summary>
public class UpdateTimeClockRequest
{
    /// <summary>
    /// Enter time.
    /// </summary>
    [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$",
        ErrorMessage = "Time should be HH:MM")]
    public string EnterTime { get; set; }

    /// <summary>
    /// Leave time.
    /// </summary>
    [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$",
        ErrorMessage = "Time should be HH:MM")]
    public string? LeaveTime { get; set; }
}