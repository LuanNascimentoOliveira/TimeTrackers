using app.Infrastructure;
using app.Models.Entities;
using app.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repository;

public class TimeTrackerRepo(
    TimeTrackerContext context
    ): ITimeTrackerRepo
{

    public async Task<bool> TimeEntryExistsAsync(TimeBank timeBank)
        => await context.TimeBanks.AnyAsync(t => t.TimeData.Date == timeBank.TimeData.Date);

    public async Task<TimeBank> AddTimeTracker(TimeBank timeBank)
    {            
        await context.TimeBanks.AddAsync(timeBank);
        await context.SaveChangesAsync();
        
        return timeBank;
    }
}