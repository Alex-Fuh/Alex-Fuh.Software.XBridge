using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Alex_Fuh.Software.XBridge.Data.Database;
public class XBridgeContextFactory : IDesignTimeDbContextFactory<XBridgeDbContext>
{
    public XBridgeDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<XBridgeDbContext>();
        optionsBuilder.UseNpgsql();

        return new XBridgeDbContext(optionsBuilder.Options);
    }
}