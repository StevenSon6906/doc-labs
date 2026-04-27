using System.Text.Json;

namespace NycParkStrategy.Strategies;

public class ConsoleStrategy : IOutputStrategy
{
    public void Write(object data)
    {
        Console.WriteLine(JsonSerializer.Serialize(data));
    }
}