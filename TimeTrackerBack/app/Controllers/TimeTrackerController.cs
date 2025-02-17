using app.Models.DTO;
using app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TimeTrackerController(ITimeTrackerService service) : ControllerBase
{
 
    [HttpPost("time-entry")]
    public async Task<IActionResult> CreateTimebanck([FromBody] TimeBankDto timeBankDto)
    {
        try
        {
            var postResult = await service.CreateTimeTracker(timeBankDto);

            return CreatedAtAction(nameof(CreateTimebanck), postResult);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex) 
        {
            return Conflict(ex.Message);
        }
    }
}