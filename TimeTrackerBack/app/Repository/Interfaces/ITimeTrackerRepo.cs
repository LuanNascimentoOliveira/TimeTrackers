using app.Entities;
using app.Models;

namespace app.Repository.Interfaces;

public interface ITimeTrackerRepo
{
    Task<bool> AddTimeTracker(TimeBank timeBank);
    Task<IEnumerable<TimeBank>> SelectTimeTrackingByDate(DateTime date);
    Task<IEnumerable<TimeBank>> GetTimeTrackingByMonth(DateTime month);
}