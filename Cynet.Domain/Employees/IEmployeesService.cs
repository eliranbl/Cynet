namespace Cynet.Domain.Employees;

/// <summary>
/// Employees service.
/// </summary>
public interface IEmployeesService
{
    /// <summary>
    /// Add employee.
    /// </summary>
    /// <param name="request">Employee request.</param>
    /// <returns>Identifier.</returns>
    Task<Guid> AddEmployeeAsync(CreateEmployeeRequest request);

    /// <summary>
    /// Get employee identifier.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <returns>Employee identifier.</returns>
    Task<Guid?> GetEmployeeIdAsync(string email);
}