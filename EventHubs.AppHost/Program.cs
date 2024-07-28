var builder = DistributedApplication.CreateBuilder(args);

var eventHub = builder.AddAzureEventHubs("eventhubns")
    .RunAsEmulator()
    .AddEventHub("hub");

builder.AddProject<Projects.EventHubsConsumer>("consumer")
    .WithReference(eventHub);

builder.AddProject<Projects.EventHubsApi>("api")
    .WithReference(eventHub);

builder.Build().Run();
