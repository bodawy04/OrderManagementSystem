
using StackExchange.Redis;

namespace Persistence;

public class CacheRepository(IConnectionMultiplexer connection) : ICacheRepository
{
    readonly IDatabase _database = connection.GetDatabase();
    public async Task<string?> GetAsync(string cacheKey)
    {
        var cacheValue = await _database.StringGetAsync(cacheKey);
        return cacheValue.IsNullOrEmpty ? null : cacheValue.ToString();
    }

    public async Task SetAsync(string cacheKey, string cacheValue, TimeSpan timeToLive)
    {
        await _database.StringSetAsync(cacheKey, cacheValue, timeToLive);
    }
}
