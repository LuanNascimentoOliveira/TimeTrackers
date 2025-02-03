using app.Models;
using app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace app.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TimeTrackerController(
    ITimeTrackerService service
    ) : ControllerBase
{


    [HttpPost("timerbanks")]
    public async Task<ActionResult> CreateTimebanck(TimeBankModel timeBankModel)
    {
        try
        {
            var postResult = await service.CreateTimeTracker(timeBankModel);

            if (!postResult)
                return BadRequest("Time already registered");

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    [HttpGet("timerbanks/dates")]
    public async Task<ActionResult> GetTimebanks(DateTime date)
    {
        try
        {
            var getResult = await service.GetTimeTrackersByDate(date);
            
            if (getResult is null)
            {
                return NotFound("No time trackers found");
            }
            
            return Ok(getResult);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    [HttpGet("timerbanks/months")]
    public async Task<ActionResult> GetTimeTrackerByMonth(DateTime month)
    {
        try
        {
            var getResult = await service.GetTimeTrackersByMonth(month);

            if (getResult is null)
            {
                return NotFound("No time trackers by month found");
            }

            return Ok(getResult);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}