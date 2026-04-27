using NycParkStrategy;
using NycParkStrategy.Strategies;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var strategyName = config["Strategy"] ?? "console";

IOutputStrategy strategy = strategyName switch
{
    "kafka" => new KafkaStrategy(
        config["Kafka:BootstrapServers"]!,
        config["Kafka:Topic"]!),
    "redis" => new RedisStrategy(
        config["Redis:Host"]!,
        int.Parse(config["Redis:Port"]!),
        config["Redis:KeyPrefix"]!),
    _ => new ConsoleStrategy()
};

var context = new DataContext(strategy);

foreach (var record in DataReader.Read("data.csv"))
{
    context.Output(record);
}

context.Close();
Console.WriteLine("Done!");
