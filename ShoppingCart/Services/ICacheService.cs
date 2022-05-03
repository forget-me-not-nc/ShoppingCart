using StackExchange.Redis;

namespace ShoppingCart.Services
{
    public interface ICacheService
    {
        Task<string> getCacheValueAsync(string cacheKey);
        Task setCacheValueAsync(string cacheKey, string cacheValue);
        Task deleteCacheKeyAsync(string cacheKey);
        Task pushValueToListAsync(string cacheKey, string value);
        Task deleteValueFromListAsync(string cacheKey, string value);
        Task<RedisValue[]> getCachedListAsync(string cacheKey);
    }
}
