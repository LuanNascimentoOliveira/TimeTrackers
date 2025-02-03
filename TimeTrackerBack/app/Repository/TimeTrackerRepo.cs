using app.Entities;
using app.Infrastructure;
using app.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repository;

public class TimeTrackerRepo(
    TimeTrackerContext context
    ): ITimeTrackerRepo
{

    public async Task<bool> AddTimeTracker(TimeBank timeBank)
    {
        var isSelect = context.TimeBanks.Any(t => t.TimeData.Date == timeBank.TimeData.Date);
        
        if (isSelect)
            return false;
        
        context.TimeBanks.Add(timeBank);
        await context.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<TimeBank>> SelectTimeTrackingByDate(DateTime date) {

        var select = await context.TimeBanks
            .Where(t => t.TimeData.Date == date.Date)
            .ToListAsync();

        return select;
    }

    public async Task<IEnumerable<TimeBank>> GetTimeTrackingByMonth(DateTime month)
    {

        var select = await context.TimeBanks
            .Where(t => t.TimeData.Year == month.Year && t.TimeData.Month == month.Month)
            .ToListAsync();

        return select;
    } 
}