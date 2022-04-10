using Microsoft.AspNetCore.Mvc;

namespace ServiceOne.Controllers
{
    [Route("api/products")]
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }
    }
}
