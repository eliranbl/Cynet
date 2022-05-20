using System.ComponentModel.DataAnnotations;

namespace Cynet.Domain.Employees;

/// <summary>
/// Create employee request.
/// </summary>
public class CreateEmployeeRequest
{

    /// <summary>
    /// First name.
    /// </summary>
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; }
}