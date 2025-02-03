using app.Models;

namespace app. Services. Interfaces;

public interface ITimeTrackerService
{
    Task<bool> CreateTimeTracker(TimeBankModel timeBankModel);

    Task<IEnumerable<TimeBankModel>> GetTimeTrackersByDate(DateTime date);
    Task<IEnumerable<TimeBankModel>> GetTimeTrackersByMonth(DateTime month);
}