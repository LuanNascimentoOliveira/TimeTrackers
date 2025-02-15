namespace app.Models.DTO
{
    public class TimeBankDto
    {
        public required DateTime TimeData { get; set; }

        public required string StartTime { get; set; }

        public required string BreakTime { get; set; }

        public required string Clockin { get; set; }

        public required string Clockout { get; set; }

        public required string Description { get; set; }
    }
}
