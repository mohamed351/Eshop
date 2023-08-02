using EShop.Core.Entities;
using EShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    public class BasketController :BaseAPIController
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }
        [HttpGet("{Id?}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string Id)
        {
            var basket = await this.basketRepository.GetBasketAsync(Id);
            return Ok(basket ?? new CustomerBasket(Id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await this.basketRepository.UpdateBasetAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string Id)
        {
            await basketRepository.DeleteBasketAsync(Id);
            return NoContent();
        }
    }
}
