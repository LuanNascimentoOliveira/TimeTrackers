using app.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure;

public class TimeTrackerContext(DbContextOptions options): DbContext(options)
{
    public DbSet<TimeBank> TimeBanks { get; set; }
}