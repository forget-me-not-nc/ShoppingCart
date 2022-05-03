using StackExchange.Redis;

namespace ShoppingCart.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _database = connectionMultiplexer.GetDatabase();
        }

        public async Task deleteCacheKeyAsync(string cacheKey)
        {
            await _database.KeyDeleteAsync(cacheKey);
        }

        public async Task deleteValueFromListAsync(string cacheKey, string value)
        {
            await _database.ExecuteAsync("LREM @cacheKey -1 @value", cacheKey, value);
        }
            
        public async Task<RedisValue[]> getCachedListAsync(string cacheKey)
        {
            return await _database.ListRangeAsync(cacheKey, 0, -1);
        }

        public async Task<string> getCacheValueAsync(string cacheKey)
        {
            return await _database.StringGetAsync(cacheKey);
        }

        public async Task pushValueToListAsync(string cacheKey, string value)
        {
            await _database.ListRightPushAsync(cacheKey, value);
        }

        public async Task setCacheValueAsync(string cacheKey, string cacheValue)
        {
            await _database.StringSetAsync(cacheKey, cacheValue);
        }
    }
}
