using EShop.API.Errors;
using EShop.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    public class BuggyController:BaseAPIController
    {
        private readonly StoreDbContext context;

        public BuggyController(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("notfound")]
        public ActionResult NotFoundRequest()
        {
            return NotFound(new APIResponse(404));
        }
        [HttpGet("servererror")]
        public ActionResult ServerError()
        {
            var thing = context.Products.Find(444);
            var thingtoReturn = thing.ToString();


            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400,"Bad Request"));
        }
        [HttpGet("badrequestparamter/{id}")]
        public ActionResult GetBadRequesrtParamter(int id)
        {
            return Ok();
        }
    }
}
