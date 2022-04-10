using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceTwo.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }
    }
}
