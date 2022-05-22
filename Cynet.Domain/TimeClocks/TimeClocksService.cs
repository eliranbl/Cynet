using AutoMapper;
using Cynet.Common.Paging;

namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clocks service.
/// </summary>
public class TimeClocksService : ITimeClocksService
{
    private readonly IMapper _mapper;
    private readonly ITimeClocksRepository _clocksRepository;

    /// <summary>
    /// Create service.
    /// </summary>
    /// <param name="mapper">Mapper.</param>
    /// <param name="clocksRepository">Clock repository,</param>
    public TimeClocksService(IMapper mapper, ITimeClocksRepository clocksRepository)
    {
        _mapper = mapper;
        _clocksRepository = clocksRepository;
    }

    /// <summary>
    /// Log to time log.
    /// </summary>
    /// <param name="employeeId">Employee identifier.</param>
    /// <param name="request">Time clock request.</param>
    /// <returns>Time clock response.</returns>
    public async Task<TimeClockResponse> LogToTimeClockAsync(Guid employeeId, TimeClockRequest request)
    {
        TimeClock timeClockResult;

        var timeClock = await _clocksRepository.GetTimeClockAsync(request.Email, request.Value);

        if (request.TimeClockType == TimeClockType.Enter)
        {
            if (timeClock is not null)
            {
                var value = request.Value.ToShortTimeString(); ;
                timeClock.EnterTime = value;
                timeClockResult = await UpdateTimeClockAsync(timeClock);
            }
            else
            {
                timeClockResult = await AddTimeClockAsync(request.Value, employeeId);
            }
        }
        else
        {
            timeClock.LeaveTime = request.Value.ToLongTimeString();
            timeClockResult = await UpdateTimeClockAsync(timeClock);
        }

        return _mapper.Map<TimeClockResponse>(timeClockResult);
    }

    /// <summary>
    /// Get time clock log.
    /// </summary>
    /// <param name="query">Time clock query.</param>
    /// <returns>Time clock response.</returns>
    public async Task<Page<TimeClockResponse>> GetTimeClockLogsAsync(TimeClockQuery query)
    {
        var result = await _clocksRepository.GetTimeClockLogAsync(query);

        return _mapper.Map<Page<TimeClockResponse>>(result);
    }

    /// <summary>
    /// Update time clock.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <param name="request">Update time clock request.</param>
    /// <returns>Time clock response.</returns>
    public async Task<TimeClockResponse> UpdateTimeClockAsync(Guid id, UpdateTimeClockRequest request)
    {
        var timeClock = await _clocksRepository.GetTimeClockAsync(id);

        if (timeClock == null) return new TimeClockResponse();

        timeClock.EnterTime = request.EnterTime;
        timeClock.LeaveTime = request.LeaveTime;

        var result = await _clocksRepository.UpdateTimeClockAsync(timeClock);

        return _mapper.Map<TimeClockResponse>(result);

    }

    /// <summary>
    /// Get time clock.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Time clock response.</returns>
    public async Task<TimeClockResponse?> GetTimeClockByIdAsync(Guid id)
    {
        var result = await _clocksRepository.GetTimeClockAsync(id);

        var response = _mapper.Map<TimeClockResponse>(result);

        return response;
    }

    /// <summary>
    /// Get time clock.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <param name="requestValue">Request value.</param>
    /// <returns>Time clock.</returns>
    public async Task<TimeClock?> GetTimeClockAsync(string email, DateTime requestValue)
    {
        return await _clocksRepository.GetTimeClockAsync(email, requestValue);
    }

    /// <summary>
    /// Get times clock by date.
    /// </summary>
    /// <param name="date">Date.</param>
    /// <returns>Employees.</returns>
    public async Task<List<TimeClockResponse>> GetAllTimesClockByDate(DateTime date)
    {
        var result = await _clocksRepository.GetAllTimesClockByDate(date);

        var timesClock = _mapper.Map<List<TimeClockResponse>>(result);

        return timesClock;
    }

    #region Private

    private async Task<TimeClock> AddTimeClockAsync(DateTime value, Guid employeeId)
    {
        var timeClock = new TimeClock
        {
            Id = Guid.NewGuid(),
            Day = value.DayOfWeek.ToString(),
            Date = value.Date,
            EnterTime = value.ToLongTimeString(),
            EmployeeId = employeeId
        };
        return await _clocksRepository.AddTimeClockAsync(timeClock);
    }

    private async Task<TimeClock> UpdateTimeClockAsync(TimeClock timeClock)
    {
        timeClock.UpdateTime = DateTime.UtcNow;

        return await _clocksRepository.UpdateTimeClockAsync(timeClock);
    }

    #endregion
}