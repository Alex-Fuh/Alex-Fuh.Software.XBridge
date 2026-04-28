using Microsoft.EntityFrameworkCore;

namespace Alex_Fuh.Software.XBridge.Data.Database;

public class XBridgeDbContext(DbContextOptions<XBridgeDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    //tables
    public DbSet<Todo> Todos => Set<Todo>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}