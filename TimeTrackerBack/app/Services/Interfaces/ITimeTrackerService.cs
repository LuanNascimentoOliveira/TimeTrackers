using app.Models;
using app.Models.DTO;
using app.Models.Entities;

namespace app. Services. Interfaces;

public interface ITimeTrackerService
{
    Task<TimeBank> CreateTimeTracker(TimeBank timeBank);
}