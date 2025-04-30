var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.FirstAspire_ApiService>("apiservice")
    .WithHttpsHealthCheck("/health");

builder.AddProject<Projects.FirstAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpsHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
