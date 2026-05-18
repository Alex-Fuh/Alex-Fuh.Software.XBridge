using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alex_Fuh.Software.XBridge.Data.Database;

public class LogMeasage
{
    [Key] public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }
    
    [ForeignKey(nameof(DayFk))]
    public Day? Day { get; set; }
    public int DayFk { get; set; }
    
    [ForeignKey(nameof(ProjectFk))]
    public Project? Project { get; set; }
    public int ProjectFk { get; set; }
    
    [ForeignKey(nameof(LocationFk))]
    public Location? Location { get; set; }
    public int LocationFk { get; set; }
}