var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

builder.AddProject<Projects.ApiApplication>("api")
    .WithReference(cache);

builder.Build().Run();
