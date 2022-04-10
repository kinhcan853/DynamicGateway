using DynamicGateway.Const;
using GatewayLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace DynamicGateway.Controllers
{
    [Route("api/products")]
    public class ProductsController : BaseApiController
    {
        private IMemoryCache _cache;
        public ProductsController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Product> productCache;
            if (!_cache.TryGetValue(MemoryCacheConst.Product, out productCache)) return NotFound();
            return Ok(productCache);
        }
    }
}
