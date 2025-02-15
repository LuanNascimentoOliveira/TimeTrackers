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
        var postResult = await service.CreateTimeTracker(timeBankDto);

        return new ObjectResult(postResult) { StatusCode = StatusCodes.Status201Created};
    }
}