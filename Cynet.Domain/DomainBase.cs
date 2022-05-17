namespace Cynet.Domain;

/// <summary>
/// Domain base.
/// </summary>
public class DomainBase
{
    /// <summary>
    /// Create time.
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}