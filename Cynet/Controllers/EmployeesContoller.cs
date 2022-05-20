using System;
using Cynet.Domain.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cynet.Controllers;

/// <summary>
/// Employees controller.
/// </summary>
[ApiController]
[Route("/v{version:ApiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public class EmployeesController : Controller
{
    private readonly IEmployeesService _employeesService;

    /// <summary>
    /// Create controller.
    /// </summary>
    /// <param name="employeesService">Employee service.</param>
    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddEmployeeAsync([FromBody] CreateEmployeeRequest request)
    {
        var isEmployeeExists = await _employeesService.GetEmployeeIdAsync(request.Email);

        if (isEmployeeExists != null && isEmployeeExists.Value != Guid.Empty)
            return BadRequest("Employee already exists");


        var result= await _employeesService.AddEmployeeAsync(request);

        return Ok(result);
    }
}