using ShoppingCart.Entities;

namespace ShoppingCart.Services
{
    public class BasketService : IBasketService
    {

        private readonly ICacheService _cacheService;

        public BasketService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task addItem(string key, string value)
        {
            await _cacheService.pushValueToListAsync(key, value);
        }

        public async Task delete(string key)
        {
            await _cacheService.deleteCacheKeyAsync(key);
        }

        public async Task delete(string key, string value)
        {
            await _cacheService.deleteValueFromListAsync(key, value);
        }

        public async Task<Basket> getBasket(string key)
        {
            var res = await _cacheService.getCachedListAsync(key);

            return new Basket
            {
                ClientId = Convert.ToInt32(key),
                ItemIds = res.Select(e => Convert.ToInt32(e)).ToList()
            };
        }
    }
}
