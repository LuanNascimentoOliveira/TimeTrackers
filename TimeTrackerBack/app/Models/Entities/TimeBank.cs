using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models.Entities;

[Table("timebank")]
public class TimeBank
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Garante o auto incremento.
    [Column("timebankId")]
    public required int TimebankId { get; set; }

    [Column("dateTimeBank")]
    public required DateTime TimeData { get; set; }

    [Column("startTimebank")]
    public required string StartTime { get; set; }

    [Column("break")]
    public required string BreakTime { get; set; }

    [Column("clockin")]
    public required string Clockin { get; set; }

    [Column("clockout")]
    public required string Clockout { get; set; }

    [Column("description")]
    public required string Description { get; set; }

}