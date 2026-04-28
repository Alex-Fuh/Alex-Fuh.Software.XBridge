using System.Text.Json.Serialization;
using Alex_Fuh.Software.XBridge.Data.Database;
using Alex_Fuh.Software.XBridge.Service;
using Alex_Fuh.Software.XBridge.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


namespace SMF.Azubi.ExamMaker;

public class Program
{
    public static async Task Main(string[] args)    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.AddServiceDefaults();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        // builder.Services.AddNpgsql<ExamMakerDbContext>("api-db");
        
        // Für die Endpunkte
        var conn = builder.Configuration.GetConnectionString("api-db");
        if (string.IsNullOrWhiteSpace(conn))
            throw new InvalidOperationException("ConnectionStrings:api-db fehlt oder ist leer.");
        builder.Services.AddNpgsql<XBridgeDbContext>(conn);
        
        // endpunkte einbinden
        // builder.Services.AddScoped<IDashboardService, DashboardService>();
        builder.Services.AddScoped<ITodoService, TodoService>();
        
        // Um Referenz schleifen zu verhindern.
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        
        var app = builder.Build();

        
        // Apply migrations at runtime
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<XBridgeDbContext>();
            await db.Database.MigrateAsync();
        }
        
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapDefaultEndpoints();
        app.MapControllers();

        app.Run();
    }
}