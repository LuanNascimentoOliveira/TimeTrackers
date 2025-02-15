using app.Models.DTO;
using app.Models.Entities;
using app.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace app.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TimeTrackerController(IMapper iMapper, ITimeTrackerService service) : ControllerBase
{

    [HttpPost("time-entry")]
    public async Task<IActionResult> CreateTimebanck([FromBody] TimeBankDto timeBankDto)
    {
            var timeBank = iMapper.Map<TimeBank>(timeBankDto);

            var postResult = await service.CreateTimeTracker(timeBank);

            var response = iMapper.Map<TimeBankDto>(postResult);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created};      
    }
}