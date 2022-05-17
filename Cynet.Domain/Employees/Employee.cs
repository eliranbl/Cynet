using Cynet.Domain.Insulations;
using Cynet.Domain.TimeClocks;

namespace Cynet.Domain.Employees;

/// <summary>
/// Employee.
/// </summary>
public class Employee : DomainBase
{
    /// <summary>
    /// Identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// First name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Time clocks.
    /// </summary>
    public virtual ICollection<TimeClock> TimeClocks { get; set; }

    /// <summary>
    /// Quarantines.
    /// </summary>
    public virtual  ICollection<Quarantine> Quarantines { get; set; }
}