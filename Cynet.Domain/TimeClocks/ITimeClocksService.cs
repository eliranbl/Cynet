using Cynet.Common.Paging;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clocks service.
/// </summary>
public interface ITimeClocksService
{
    /// <summary>
    /// Log to time log.
    /// </summary>
    /// <param name="employeeId">Employee identifier.</param>
    /// <param name="request">Time clock request.</param>
    /// <returns>Time clock response.</returns>
    Task<TimeClockResponse> LogToTimeClockAsync(Guid employeeId, TimeClockRequest request);

    /// <summary>
    /// Get time clock log.
    /// </summary>
    /// <param name="query">Time clock query.</param>
    /// <returns>Time clock response.</returns>
    Task<Page<TimeClockResponse>> GetTimeClockLogsAsync(TimeClockQuery query);

    /// <summary>
    /// Update time clock.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request">Update time clock request.</param>
    /// <returns>Time clock response.</returns>
    Task<TimeClockResponse> UpdateTimeClockAsync(Guid id, UpdateTimeClockRequest request);

    /// <summary>
    /// Get time clock by identifier.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Time clock response.</returns>
    Task<TimeClockResponse?> GetTimeClockByIdAsync(Guid id);

    /// <summary>
    /// Get time clock.
    /// </summary>
    /// <param name="Email">Employee email.</param>
    /// <param name="requestValue">Request value.</param>
    /// <returns>Time clock.</returns>
    Task<TimeClock?> GetTimeClockAsync(string Email, DateTime requestValue);

    /// <summary>
    /// Get times clock by date.
    /// </summary>
    /// <param name="date">Date.</param>
    /// <returns>Times clock.</returns>
    Task<List<TimeClockResponse>> GetAllTimesClockByDate(DateTime date);
}