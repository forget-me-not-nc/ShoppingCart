using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Entities;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _service;
        public BasketController(IBasketService service)
        {
            _service = service;
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<Basket>> GetBasket(string clientId)
        {
            return Ok(await _service.getBasket(clientId));
        }

        [HttpDelete("{clientId}")]
        public async Task<ActionResult> Delete(string clientId)
        {
            await _service.delete(clientId);

            return Ok();
        }

        [HttpDelete("{clientId}/{itemId}")]
        public async Task<ActionResult> Delete(string clientId, string itemId)
        {
            await _service.delete(clientId, itemId);

            return Ok();
        }

        [HttpPost("{clientId}/{itemId}")]
        public async Task<ActionResult> PushItem(string clientId, string itemId)
        {
            await _service.addItem(clientId, itemId);

            return Ok();
        }
    }
}
