using AutoMapper;
using EShop.API.DTOS;
using EShop.API.Errors;
using EShop.API.Extentions;
using EShop.Core.Entities.Orders;
using EShop.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
 
    public class OrdersController:BaseAPIController
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }
        [HttpPost]
        [Authorize]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO dTO)
        {
            var email = User.CurrentUserEmail();
            var address = mapper.Map<Address>(dTO.ShiptoAddress);
            var order = await orderService.CreateOrderAsync(email, dTO.DeliveyMethod, dTO.BasetID, address);
            if(order == null)
            {
                return BadRequest(new APIResponse(400, "Problem in Order"));
            }

            return Ok(new OrderDTO() { BasetID = dTO.BasetID, DeliveyMethod = dTO.DeliveyMethod, ShiptoAddress = dTO.ShiptoAddress });
        }
    }
}
