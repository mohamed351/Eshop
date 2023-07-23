
using EShop.Core.Entities;
using EShop.Core.Interfaces;
using EShop.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
       
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await productRepository.GetProductsAsync());
        }
        [HttpGet("{ID?}")]
        public async Task<ActionResult<Product>> GetProductByID(int? ID)
        {
            if(ID == null)
            {
                return BadRequest();
            }
            var product = await productRepository.GetProductAsync(ID.Value);
            if(product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }
    }
}
