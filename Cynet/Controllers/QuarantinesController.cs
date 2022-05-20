using Cynet.Domain.Quarantines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cynet.Controllers;

/// <summary>
/// Quarantines controller.
/// </summary>
[ApiController]
[Route("/v{version:ApiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public class QuarantinesController : ControllerBase
{
    private  readonly  IQuarantinesService  _quarantinesService;

    /// <summary>
    /// Create controller.
    /// </summary>
    /// <param name="quarantinesService">Quarantines service.</param>
    public QuarantinesController(IQuarantinesService quarantinesService)
    {
        _quarantinesService = quarantinesService;
    }

    [HttpPost]
    public async Task<IActionResult> DeclarePositiveAsync(QuarantineRequest request)
    {
        await _quarantinesService.DeclarePositiveAsync(request);

        return Ok();
    }
}