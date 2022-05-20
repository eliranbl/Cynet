using AutoMapper;

namespace Cynet.Domain.Employees;

/// <summary>
/// Employees service.
/// </summary>
public class EmployeesService : IEmployeesService
{
    private readonly IEmployeesRepository _employeesRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Create service.
    /// </summary>
    /// <param name="employeesRepository">Employee repository.</param>
    /// <param name="mapper">Mapper.</param>
    public EmployeesService(IEmployeesRepository employeesRepository, IMapper mapper)
    {
        _employeesRepository = employeesRepository;
        _mapper = mapper;
    }


    public async Task<Guid> AddEmployeeAsync(CreateEmployeeRequest request)
    {
        var employee = _mapper.Map<Employee>(request);

        var result = await _employeesRepository.AddEmployeeAsync(employee);
        
        return result.Id; 
    }

    /// <summary>
    /// Get employee identifier.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <returns>Employee identifier.</returns>
    public async Task<Guid?> GetEmployeeIdAsync(string email)
    {
        var employee = await _employeesRepository.GetEmployeeByEmailAsync(email);
        
        return employee is not null ? employee.Id : new Guid();
    }
}