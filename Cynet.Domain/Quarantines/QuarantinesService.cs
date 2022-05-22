using Cynet.Domain.Emails;
using Cynet.Domain.Insulations;
using Cynet.Domain.TimeClocks;

namespace Cynet.Domain.Quarantines;

/// <summary>
/// Quarantines service.
/// </summary>
public class QuarantinesService : IQuarantinesService
{
    private readonly IQuarantinesRepository _quarantinesRepository;
    private readonly ITimeClocksService _timeClocksService;
    private readonly IEmailsService _emailsService;

    /// <summary>
    /// Create service.
    /// </summary>
    /// <param name="quarantinesRepository">Quarantines service.</param>
    /// <param name="timeClocksService">Time clocks service.</param>
    /// <param name="emailsService">Emails service.</param>
    public QuarantinesService(
        IQuarantinesRepository quarantinesRepository,
        ITimeClocksService timeClocksService,
        IEmailsService emailsService)
    {
        _quarantinesRepository = quarantinesRepository;
        _timeClocksService = timeClocksService;
        _emailsService = emailsService;
    }

    public async Task DeclarePositiveAsync(QuarantineRequest request)
    {
        var result = await _timeClocksService.GetAllTimesClockByDate(request.FromDate);

        var quarantines = new List<Quarantine>();

        foreach (var item in result)
        {
            var emailSent = await _emailsService.SendEmailAsync(new SendQuarantineEmailRequest
            {
                Email = item.Employee.Email,
                FromDate = request.FromDate,
                UntilDate = request.FromDate.AddDays(-7)
            });

            var quarantine = new Quarantine
            {
                Id = Guid.NewGuid(),
                EmployeeId = item.EmployeeId,
                FromDate = request.FromDate,
                UntilDate = request.FromDate.AddDays(7),
                CreateTime = DateTime.UtcNow,
                IsReporter = false,
                SentEmail = emailSent
            };

            if (request.Email.Equals(item.Employee.Email))
                quarantine.IsReporter = true;

            quarantines.Add(quarantine);
        }

        await _quarantinesRepository.AddQuarantineRangeAsync(quarantines);
    }
}