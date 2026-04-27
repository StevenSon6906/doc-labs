using Confluent.Kafka;
using System.Text.Json;

namespace NycParkStrategy.Strategies;

public class KafkaStrategy : IOutputStrategy
{
    private readonly IProducer<Null, string> _producer;
    private readonly string _topic;

    public KafkaStrategy(string bootstrapServers, string topic)
    {
        var config = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
        _topic = topic;
    }

    public void Write(object data)
    {
        var json = JsonSerializer.Serialize(data);
        _producer.Produce(_topic, new Message<Null, string> { Value = json });
    }

    public void Close()
    {
        _producer.Flush(TimeSpan.FromSeconds(10));
        _producer.Dispose();
    }
}