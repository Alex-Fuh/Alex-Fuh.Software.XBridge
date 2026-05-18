using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alex_Fuh.Software.XBridge.Data.Database;

public class Project
{
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    
    [InverseProperty(nameof(LogMeasage.Project))]
    public ICollection<LogMeasage> LogMeasages { get; set; } = new List<LogMeasage>();
}