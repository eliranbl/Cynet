using Cynet.Common.Paging;
using Cynet.Domain.Employees;
using Cynet.Domain.TimeClocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cynet.Controllers;

/// <summary>
/// Time clocks.
/// </summary>
[ApiController]
[Route("/v{version:ApiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public class TimesClockController : ControllerBase
{
    private readonly ITimeClocksService _timeClocksService;
    private readonly IEmployeesService _employeesService;

    /// <summary>
    /// Create controller.
    /// </summary>
    /// <param name="timeClocksService">Time clocks services.</param>
    /// <param name="employeesService">Employees service.</param>
    public TimesClockController(ITimeClocksService timeClocksService, IEmployeesService employeesService)
    {
        _timeClocksService = timeClocksService;
        _employeesService = employeesService;
    }

    /// <summary>
    /// Log to time clock.
    /// </summary>
    /// <param name="request">Time clock request.</param>
    /// <returns>Time clock response.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(TimeClockResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> LogToTimeClockAsync([FromBody] TimeClockRequest request)
    {
        if (!Enum.IsDefined(typeof(TimeClockType), request.TimeClockType))
            return BadRequest("Your clock type is undefined");

        var employee = await _employeesService.GetEmployeeIdAsync(request.EmployeeEmail);

        if (employee != null && employee.Value == Guid.Empty)
            return NotFound("Employee not found");

        if (request.TimeClockType == TimeClockType.Leave)
        {
            var timeClock = await _timeClocksService.GetTimeClockAsync(request.EmployeeEmail, request.Value);

            if (timeClock is null)
                return BadRequest("You need to enter before you leave");
        }

        var result = await _timeClocksService.LogToTimeClockAsync(employee.Value, request);

        return Ok(result);
    }

    /// <summary>
    /// Get time clock logs
    /// </summary>
    /// <param name="query"></param>
    /// <returns>Time clocks response.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(Page<TimeClockResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTimeClockLogsAsync([FromQuery] TimeClockQuery query)
    {
        var result = await _timeClocksService.GetTimeClockLogsAsync(query);

        return Ok(result);
    }

    [HttpPut("{id}/UpdateAsync")]
    public async Task<IActionResult> UpdateTimeClockAsync([FromRoute] Guid id, [FromBody] UpdateTimeClock request)
    {
        var timeClock = await _timeClocksService.GetTimeClockByIdAsync(id);
        if (timeClock == null)
            return NotFound();

        var updated = await _timeClocksService.UpdateTimeClockAsync(id, request);

        return Ok(updated);
    }
}
