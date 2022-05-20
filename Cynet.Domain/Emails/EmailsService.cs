namespace Cynet.Domain.Emails;

/// <summary>
/// Send email request.
/// </summary>
public class EmailsService : IEmailsService
{
    /// <summary>
    /// Send email.
    /// </summary>
    /// <param name="request">Send email request.</param>
    /// <returns>Boolean.</returns>
    public async Task<bool> SendEmailAsync(SendQuarantineEmailRequest request)
    {
        return true;;
    }
}