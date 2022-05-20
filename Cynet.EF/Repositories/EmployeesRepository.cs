using Cynet.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace Cynet.EF.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    private readonly CynetDbContext _context;

    /// <summary>
    /// Create repository.
    /// </summary>
    /// <param name="context"></param>
    public EmployeesRepository(CynetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Add employee.
    /// </summary>
    /// <param name="employee">Employee.</param>
    /// <returns>Employee.</returns>
    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        var result = await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return result.Entity;
    }


    /// <summary>
    /// Get employee by identifier.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <returns>Employee</returns>
    public async Task<Employee?> GetEmployeeByEmailAsync(string email)
    {
        return await _context.Employees.FirstOrDefaultAsync(x => x.Email == email);
    }
}