using app.Models;
using app.Models.Entities;

namespace app.Repository.Interfaces;

public interface ITimeTrackerRepo
{
    Task<TimeBank> AddTimeTracker(TimeBank timeBank);
}