using AutoMapper;
using EShop.API.DTOS;
using EShop.Core.Entities;

namespace EShop.API.Mappings
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDTO, String>
    {
        private readonly IConfiguration configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return this.configuration["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
