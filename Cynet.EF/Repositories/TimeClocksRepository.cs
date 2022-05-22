using Cynet.Common.Paging;
using Cynet.Domain.TimeClocks;
using Microsoft.EntityFrameworkCore;

namespace Cynet.EF.Repositories;

/// <summary>
/// Time clocks repository.
/// </summary>
public class TimeClocksRepository : ITimeClocksRepository
{
    private readonly CynetDbContext _context;

    /// <summary>
    /// Create repository.
    /// </summary>
    /// <param name="context"></param>
    public TimeClocksRepository(CynetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get time clock.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <returns>Time clock.</returns>
    public async Task<TimeClock> GetTimeClockAsync(Guid id)
    {
        var result = await _context.TimeClocks.FindAsync(id);
        return result;
    }

    public async Task<TimeClock> AddTimeClockAsync(TimeClock timeClock)
    {
        timeClock.CreateTime = DateTime.UtcNow;

        var result = await _context.TimeClocks.AddAsync(timeClock);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Get time clock log.
    /// </summary>
    /// <param name="query">Time clock query.</param>
    /// <returns>Time clocks.</returns>
    public async Task<Page<TimeClock>> GetTimeClockLogAsync(TimeClockQuery query)
    {
        var timeClocksQueryable = _context.TimeClocks.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Email))
        {
            timeClocksQueryable = timeClocksQueryable.Where(x => x.Employee.Email == query.Email);
        }

        if (query.Date.HasValue)
        {
            timeClocksQueryable = timeClocksQueryable.Where(x => x.Date == query.Date);
        }

        return await timeClocksQueryable.AsQueryable()
            .ToPageAsync(query.PageNo, query.PageSize);
    }

    /// <summary>
    /// Update time clock.
    /// </summary>
    /// <param name="timeClock">Time clock.</param>
    /// <returns>Time clock.</returns>
    public async Task<TimeClock> UpdateTimeClockAsync(TimeClock timeClock)
    {
        timeClock.UpdateTime = DateTime.UtcNow;

        var result = await _context.TimeClocks.FindAsync(timeClock.Id);

        await _context.SaveChangesAsync();

        return result;
    }

    /// <summary>
    /// Get time clock.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <param name="requestValue">Request value.</param>
    /// <returns>Time clock.</returns>
    public async Task<TimeClock?> GetTimeClockAsync(string email, DateTime requestValue)
    {
        var result = await _context.TimeClocks
            .Include(x => x.Employee)
            .SingleOrDefaultAsync(x =>
                x.Employee.Email == email
                && x.Date == requestValue.Date);

        return result;
    }

    /// <summary>
    /// Get times clock by date.
    /// </summary>
    /// <param name="date">Date.</param>
    /// <returns>Times clock.</returns>
    public async Task<List<TimeClock>> GetAllTimesClockByDate(DateTime date)
    {
        return await _context.TimeClocks.Where(x => x.Date == date )
            .Include(x => x.Employee)
            .ThenInclude(x=>x.Quarantines)
            .ToListAsync();
    }
}