using Cynet.Common.Paging;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clocks repository.
/// </summary>
public interface ITimeClocksRepository
{
    Task<TimeClock> GetTimeClockAsync();

    /// <summary>
    /// Log to time clock.
    /// </summary>
    /// <param name="employeeId">Employee identifier.</param>
    /// <returns>Boolean.</returns>
    Task<bool> LogToTimeClockAsync(int employeeId);

    /// <summary>
    /// Get time clock log.
    /// </summary>
    /// <param name="query">Time clock query.</param>
    /// <returns>Time clocks.</returns>
    Task<Page<TimeClock>> GetTimeClockLogAsync(TimeClockQuery query);

    /// <summary>
    /// Update time clock.
    /// </summary>
    /// <param name="timeClock">Time clock.</param>
    /// <returns>Time clock.</returns>
    Task<TimeClock> UpdateTimeClockAsync(TimeClock timeClock);
}