using ShoppingCart.Entities;

namespace ShoppingCart.Services
{
    public interface IBasketService
    {
        public Task<Basket> getBasket(string key);
        Task delete(string key);
        Task delete(string key, string value);
        Task addItem(string key, string value);
    }
}
