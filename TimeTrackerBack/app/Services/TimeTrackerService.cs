using app.Models.Entities;
using app.Repository.Interfaces;
using app.Services.Interfaces;

namespace app.Services;

public class TimeTrackerService(
    ITimeTrackerRepo repo
    ): ITimeTrackerService
{
    //TODO incluir no futuro badrequest, talves m[a formatacao.
    public async Task<TimeBank> CreateTimeTracker(TimeBank timeBank)
    {
        return await repo.AddTimeTracker(timeBank)
            ?? throw new InvalidOperationException();
    }
}