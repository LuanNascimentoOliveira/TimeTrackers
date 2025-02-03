namespace app.Models;

public class TimeBankModel
{
    public required DateTime TimeData { get; set; }
    public required string StartTime { get; set; }
    public required string BreakTime { get; set; }
    public required string Clockin { get; set; }
    public required string Clockout { get; set; }
    public required string Description { get; set; }
}