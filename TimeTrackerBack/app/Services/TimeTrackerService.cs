using app.Models.DTO;
using app.Models.Entities;
using app.Repository.Interfaces;
using app.Services.Interfaces;
using AutoMapper;

namespace app.Services;

public class TimeTrackerService(
    ITimeTrackerRepo repo,
    IMapper mapper
    ): ITimeTrackerService
{
    public async Task<TimeBankDto> CreateTimeTracker(TimeBankDto timeBankDto)
    {
        ValidateTimeBankDto(timeBankDto);

        var timeBank = mapper.Map<TimeBank>(timeBankDto);        

        await TimeEntryExists(timeBank);

        var addTime = await repo.AddTimeTracker(timeBank);

        return mapper.Map<TimeBankDto>(addTime);
    }

    private static void ValidateTimeBankDto(TimeBankDto timeBankDto)
    {
        if (string.IsNullOrEmpty(timeBankDto.Clockin))
        {
            throw new ArgumentNullException("Clock-in data is missing.");
        }
    }

    private async Task TimeEntryExists(TimeBank timeBank)
    {
        var timeEntryExists = await repo.TimeEntryExistsAsync(timeBank);

        if (timeEntryExists)
            throw new InvalidOperationException("A time entry already exists for this date.");
    }

}