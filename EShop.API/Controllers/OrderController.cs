using EShop.API.DTOS;
using EShop.Core.Entities.Orders;
using EShop.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController:BaseAPIController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        //[HttpPost]
        //public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDTO)
        //{

        //}
    }
}
