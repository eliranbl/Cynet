using Cynet.Common.Paging;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clocks service.
/// </summary>
public interface ITimeClocksService
{
    /// <summary>
    /// Log to time clock.
    /// </summary>
    /// <param name="employeeId">Employee identifier.</param>
    /// <returns></returns>
    Task<bool> LogToTimeClockAsync(int employeeId);

    /// <summary>
    /// Get time clock log.
    /// </summary>
    /// <param name="query">Time clock query.</param>
    /// <returns>Time clocks.</returns>
    Task<Page<TimeClockResponse>> GetTimeClockLogAsync(TimeClockQuery query);

    /// <summary>
    /// Update time clock.
    /// </summary>
    /// <param name="request">Update time clock request.</param>
    /// <returns></returns>
    Task<TimeClockResponse> UpdateTimeClockAsync(UpdateTimeClock request);
}