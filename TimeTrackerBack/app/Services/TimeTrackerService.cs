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
        await TimeEntryExists(ValidateTimeBankDto(timeBankDto));

        var addTime = await repo.AddTimeTracker(ValidateTimeBankDto(timeBankDto));

        return mapper.Map<TimeBankDto>(addTime);
    }

    private TimeBank ValidateTimeBankDto(TimeBankDto timeBankDto)
    {
        if (string.IsNullOrEmpty(timeBankDto.StartTime))
            throw new ArgumentNullException(nameof(timeBankDto.StartTime), message: "data is missing.");

        return mapper.Map<TimeBank>(timeBankDto);
    }

    private async Task TimeEntryExists(TimeBank timeBank)
    {
        var timeEntryExists = await repo.TimeEntryExistsAsync(timeBank);

        if (timeEntryExists)
            throw new InvalidOperationException("A time entry already exists for this date.");
    }

}