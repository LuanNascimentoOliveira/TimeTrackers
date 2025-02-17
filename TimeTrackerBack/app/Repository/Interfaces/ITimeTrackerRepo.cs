using app.Models.Entities;

namespace app.Repository.Interfaces;

public interface ITimeTrackerRepo
{
    Task<bool> TimeEntryExistsAsync(TimeBank timeBank);
    Task<TimeBank> AddTimeTracker(TimeBank timeBank);
}