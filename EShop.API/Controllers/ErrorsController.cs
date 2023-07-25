using EShop.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorsController : BaseAPIController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIResponse(code));
        }
    }
}
