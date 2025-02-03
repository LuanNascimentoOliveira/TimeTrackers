using app.Adapters.Interfaces;
using app.Models;
using app.Repository.Interfaces;
using app.Services.Interfaces;

namespace app.Services;

public class TimeTrackerService(
    ITimeTrackerRepo repo,
    IBaseAdapter baseAdapter
    ): ITimeTrackerService
{
    public async Task<bool> CreateTimeTracker(TimeBankModel timeBankModel)
    { 
        var returnAdapter = baseAdapter.MapModelToEntity(timeBankModel);
        
        var addTime =  await repo.AddTimeTracker(returnAdapter);
        
        if (!addTime)
           return false;
        
        return true;
    }

    public async Task<IEnumerable<TimeBankModel>> GetTimeTrackersByDate(DateTime date)
    {
        var select = await repo.SelectTimeTrackingByDate(date);

        var returnAdpter = baseAdapter.MapEntityToModel(select);
        
        return returnAdpter;
    }

    public async Task<IEnumerable<TimeBankModel>> GetTimeTrackersByMonth(DateTime month)
    {
        var select = await repo.GetTimeTrackingByMonth(month);

        var returnAdpter = baseAdapter.MapEntityToModel(select);

        return returnAdpter;
    }
}