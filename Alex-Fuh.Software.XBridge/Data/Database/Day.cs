using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alex_Fuh.Software.XBridge.Data.Database;

public class Day
{
    [Key] 
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    [InverseProperty(nameof(LogMeasage.Day))]
    public ICollection<LogMeasage> LogMeasages { get; set; } = new List<LogMeasage>();
}