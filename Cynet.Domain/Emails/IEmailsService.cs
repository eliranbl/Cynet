namespace Cynet.Domain.Emails;

/// <summary>
/// Email service.
/// </summary>
public interface IEmailsService
{
    /// <summary>
    /// Send email.
    /// </summary>
    /// <param name="request">Send email request.</param>
    /// <returns>Boolean.</returns>
    Task<bool> SendEmailAsync(SendQuarantineEmailRequest request);
}