using ApiApplication.APIs.Errors;
using ApiApplication.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ApiBaseController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            this._context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var product = _context.Products.Find(100);
            if (product is null) return NotFound(new ErrorResponse(404));

            return Ok(product);
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _context.Products.Find(100);
            return Ok(product.ToString());
        }

        [HttpGet("badrequest")]
        public ActionResult BadRequest()
        {
            return BadRequest(new ErrorResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult BadRequest(int id)
        {
            return Ok();
        }
    }
}
