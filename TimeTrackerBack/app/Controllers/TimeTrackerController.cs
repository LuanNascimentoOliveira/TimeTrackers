using app.Models.DTO;
using app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TimeTrackerController(ITimeTrackerService service) : ControllerBase
{
 
    [HttpPost("time-entry")]
    public async Task<IActionResult> CreateTimebank([FromBody] TimeBankDto timeBankDto)
    {
        var postResult = await service.CreateTimeTracker(timeBankDto);

        return CreatedAtAction(nameof(CreateTimebank), postResult);
    }
}