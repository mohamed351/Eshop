using EShop.API.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController:ControllerBase
    {
        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object value)
        {
            return new NotFoundObjectResult(new APIResponse(404,value.ToString()));
        }
       

    }
    
}
