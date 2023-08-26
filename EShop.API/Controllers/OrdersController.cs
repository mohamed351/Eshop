using AutoMapper;
using EShop.API.DTOS;
using EShop.API.Errors;
using EShop.API.Extentions;
using EShop.Core.Entities.Orders;
using EShop.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    [Authorize]
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
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList< OrderToReturnDto>>> GetOrdersForUser()
        {
            var email = User.CurrentUserEmail();
            var orders = await orderService.GetOrderFromUserAsync(email);
            return Ok(mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByID(int ID)
        {
            var email = User.CurrentUserEmail();
            var order = await orderService.GetOrderByID(ID, email);
            if(order == null)
            {
                return NotFound(new APIResponse(404));
            }
            return mapper.Map<OrderToReturnDto>(order);
        }
        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            return Ok(await this.orderService.GetDeliveryMethodsAsync());
        }

    }
}
