using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alex_Fuh.Software.XBridge.Data.Database;

public class Location
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = "";
    
    [InverseProperty(nameof(LogMeasage.Location))]
    public ICollection<LogMeasage> LogMeasages { get; set; } = new List<LogMeasage>();
}