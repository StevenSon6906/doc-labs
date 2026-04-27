using StackExchange.Redis;
using System.Text.Json;

namespace NycParkStrategy.Strategies;

public class RedisStrategy : IOutputStrategy
{
    private readonly IDatabase _db;
    private readonly string _keyPrefix;
    private int _counter = 0;

    public RedisStrategy(string host, int port, string keyPrefix)
    {
        var connection = ConnectionMultiplexer.Connect($"{host}:{port}");
        _db = connection.GetDatabase();
        _keyPrefix = keyPrefix;
    }

    public void Write(object data)
    {
        var key = $"{_keyPrefix}{_counter++}";
        _db.StringSet(key, JsonSerializer.Serialize(data));
    }
}