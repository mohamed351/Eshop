using AutoMapper;
using EShop.API.DTOS;
using EShop.Core.Entities;

namespace EShop.API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(a=> a.ProductBrand , o =>  o.MapFrom(c=> c.ProductBrand.Name))
                .ForMember(a=> a.ProductType , o=> o.MapFrom(c=> c.ProductType.Name))
                .ForMember(a=> a.PictureUrl , o=> o.MapFrom<ProductUrlResolver>());
        }
    }
}
