using app.Models.DTO;

namespace app. Services. Interfaces;

public interface ITimeTrackerService
{
    Task<TimeBankDto> CreateTimeTracker(TimeBankDto timeBankDto);
}