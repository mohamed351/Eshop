using AutoMapper;
using EShop.API.DTOS;
using EShop.Core.Entities;
using EShop.Core.Entities.Identity;

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

            CreateMap<Address, AddressDTO>()
                 .ForMember(a => a.City, o => o.MapFrom(c => c.City))
                 .ForMember(a => a.Street, o => o.MapFrom(c => c.Street))
                 .ForMember(a => a.ZipCode, o => o.MapFrom(c => c.ZipCode));

            CreateMap<AddressDTO , Core.Entities.Orders.Address> ();

        }
    }
}
