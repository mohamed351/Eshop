
using AutoMapper;
using EShop.API.DTOS;
using EShop.Core.Entities;
using EShop.Core.Interfaces;
using EShop.Core.Specifications;
using EShop.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.API.Controllers
{
   
    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductType> typeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productRepo ,
            IGenericRepository<ProductBrand> brandRepo ,
            IGenericRepository<ProductType> typeRepo,
            IMapper mapper)
        {
       
          
            this.productRepo = productRepo;
            this.brandRepo = brandRepo;
            this.typeRepo = typeRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDTO>>> GetProducts()
        {
            var specficiation = new ProductWithTypeAndBrandSpecification();
            return Ok(this.mapper.Map<List<ProductToReturnDTO>>( await productRepo.ListAllAsync(specficiation)));
        }
        [HttpGet("{ID?}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProductByID(int? ID)
        {
            if(ID == null)
            {
                return BadRequest();
            }
            var product = await productRepo.GetEntityWithSpec(new ProductWithTypeAndBrandSpecification(ID.Value));
            if(product == null)
            {
                return NotFound();
            }
            
            return Ok(this.mapper.Map<List<ProductToReturnDTO>>( product));
        }
        [HttpGet("brand")]
        public async Task<ActionResult<ProductBrand>> GerBrands()
        {
            return Ok(await brandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            return Ok(await typeRepo.ListAllAsync());
        }
    }
}
