namespace Cynet.Domain.TimeClocks;

/// <summary>
/// Time clock query.
/// </summary>
public class TimeClockQuery
{
    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Day.
    /// </summary>
    public string? Day { get; set; }

    /// <summary>
    /// Date.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Page number.
    /// </summary>
    public int PageNo { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    public int PageSize { get; set; }
}