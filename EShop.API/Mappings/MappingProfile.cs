using AutoMapper;
using EShop.API.DTOS;
using EShop.Core.Entities;
using EShop.Core.Entities.Identity;
using EShop.Core.Entities.Orders;

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

            CreateMap<Core.Entities.Identity.Address, AddressDTO>()
                 .ForMember(a => a.City, o => o.MapFrom(c => c.City))
                 .ForMember(a => a.Street, o => o.MapFrom(c => c.Street))
                 .ForMember(a => a.ZipCode, o => o.MapFrom(c => c.ZipCode));


   

            CreateMap<AddressDTO , Core.Entities.Orders.Address> ();
            CreateMap<AddressDTO, Core.Entities.Orders.Address>().ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(a=> a.ShippingPrice , a=> a.MapFrom(a=> a.DeliveryMethod.Price));
             
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(a=> a.ProductName , a=> a.MapFrom(a=> a.ProductItemOrdered.ProductName))
                .ForMember(a=> a.ProductId , a=> a.MapFrom(a=> a.ProductItemOrdered.ProductItemId))
                .ForMember(a=> a.PictureUrl, a=> a.MapFrom<OrderItemUrlResolver>());

        }
    }
}
