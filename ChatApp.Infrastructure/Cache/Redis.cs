using StackExchange.Redis;

namespace ChatApp.Infrastructure.Cache;

public class Redis
{
  private readonly ConnectionMultiplexer _redis;
  private readonly IDatabase _database;

  public Redis(string hostName, string portNumber, string password)
  {
    _redis = ConnectionMultiplexer.Connect($"{hostName}:{portNumber},password={password}");
    _database = _redis.GetDatabase();
  }

  public async Task SetString(string key, string value)
  {
    await _database.StringSetAsync(key, value);
  }

  public async Task<string> GetString(string key)
  {
    return await _database.StringGetAsync(key);
  }
}
