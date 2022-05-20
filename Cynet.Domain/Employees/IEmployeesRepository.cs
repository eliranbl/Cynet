namespace Cynet.Domain.Employees;

/// <summary>
/// Employees repository.
/// </summary>
public interface IEmployeesRepository
{
    /// <summary>
    /// Add employee.
    /// </summary>
    /// <param name="employee">Employee.</param>
    /// <returns>Employee.</returns>
    Task<Employee> AddEmployeeAsync(Employee employee);

    /// <summary>
    /// Get employee by email.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <returns>Employee</returns>
    Task<Employee?> GetEmployeeByEmailAsync(string  email);
}