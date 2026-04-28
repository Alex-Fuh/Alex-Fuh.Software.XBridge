var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("db-container")
    .WithDataVolume()
    .AddDatabase("api-db");

var api = builder.AddProject<Projects.Alex_Fuh_Software_XBridge>("api")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();