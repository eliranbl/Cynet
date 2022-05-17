using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cynet.Common.Paging;
using Cynet.Domain.TimeClocks;

namespace Cynet.EF.Repositories;

/// <summary>
/// Time clocks repository.
/// </summary>
public class TimeClocksRepository : ITimeClocksRepository
{
    private  readonly CynetDbContext _context;

    /// <summary>
    /// Create repository.
    /// </summary>
    /// <param name="context"></param>
    public TimeClocksRepository(CynetDbContext context)
    {
        _context = context;
    }

    public Task<TimeClock> GetTimeClockAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Log to time clock.
    /// </summary>
    /// <param name="employeeId">Employee identifier.</param>
    /// <returns>Boolean.</returns>
    public Task<bool> LogToTimeClockAsync(int employeeId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get time clock log.
    /// </summary>
    /// <param name="query">Time clock query.</param>
    /// <returns>Time clocks.</returns>
    public Task<Page<TimeClock>> GetTimeClockLogAsync(TimeClockQuery query)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update time clock.
    /// </summary>
    /// <param name="timeClock">Time clock.</param>
    /// <returns>Time clock.</returns>
    public Task<TimeClock> UpdateTimeClockAsync(TimeClock timeClock)
    {
        throw new NotImplementedException();
    }
}