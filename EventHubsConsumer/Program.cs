using Azure.Messaging.EventHubs.Consumer;
using EventHubsConsumer;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("eventhubns");

builder.Services.AddSingleton(sp =>
    new EventHubConsumerClient(
        EventHubConsumerClient.DefaultConsumerGroupName,
        connectionString,
        "hub")
);

builder.Services.AddHostedService<Consumer>();

var host = builder.Build();
host.Run();
