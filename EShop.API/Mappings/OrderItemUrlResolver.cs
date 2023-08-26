using AutoMapper;
using EShop.API.DTOS;
using EShop.Core.Entities.Orders;
using Microsoft.Extensions.Configuration;

namespace EShop.API.Mappings
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration configuration;

        public OrderItemUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductItemOrdered.PictureUrl))
            {
                return configuration["ApiUrl"] + source.ProductItemOrdered.PictureUrl;
            }
            return null;
        }
    }
}
