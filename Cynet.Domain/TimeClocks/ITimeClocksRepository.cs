using Cynet.Common.Paging;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clocks repository.
/// </summary>
public interface ITimeClocksRepository
{
    /// <summary>
    /// Get time clock.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Time clock.</returns>
    Task<TimeClock?> GetTimeClockAsync(Guid id);

    /// <summary>
    /// Add time clock.
    /// </summary>
    /// <param name="timeClock">Time clock.</param>
    /// <returns></returns>
    Task<TimeClock> AddTimeClockAsync(TimeClock timeClock);

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

    /// <summary>
    /// Get time clock.
    /// </summary>
    /// <param name="employeeEmail">Employee email.</param>
    /// <param name="requestValue">Request value.</param>
    /// <returns>Time clock.</returns>
    Task<TimeClock?> GetTimeClockAsync(string employeeEmail, DateTime requestValue);

    /// <summary>
    /// Get times clock by date.
    /// </summary>
    /// <param name="date">Date.</param>
    /// <returns>Times clock.</returns>
    Task<List<TimeClock>> GetAllTimesClockByDate(DateTime date);
}