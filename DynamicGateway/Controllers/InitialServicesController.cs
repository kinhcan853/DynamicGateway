using DynamicGateway.Const;
using GatewayLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DynamicGateway.Controllers
{
    [Route("api/initial")]
    public class InitialServicesController : BaseApiController
    {
        private IMemoryCache _cache;
        public InitialServicesController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> PostInitial([FromBody] ServiceInfo service)
        {
            List<ServiceInfo> services;
            if (!_cache.TryGetValue(MemoryCacheConst.MicroService, out services))
            {
                services = new List<ServiceInfo>();
                services.Add(service);
                _cache.Set(MemoryCacheConst.MicroService, services, cacheEntryOptions);
                await SyncProducts(service.ServiceUrl);
                return Ok();
            }
            var exited = services.Any(x => x.ServiceName.Equals(service.ServiceName));
            if (!exited)
            {
                services.Add(service);
                _cache.Set(MemoryCacheConst.MicroService, services, cacheEntryOptions);
                await SyncProducts(service.ServiceUrl);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult RemoveInitial(string serviceName)
        {
            List<ServiceInfo> services;
            if (!_cache.TryGetValue(MemoryCacheConst.MicroService, out services))
            {
                return BadRequest();
            }
            var exited = services.SingleOrDefault(x => x.ServiceName.Equals(serviceName));
            if (exited is null) return NotFound();
            services.Remove(exited);
            _cache.Set(MemoryCacheConst.MicroService, services, cacheEntryOptions);
            RemoveRangeProducts(serviceName);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetInitial()
        {
            List<ServiceInfo> services;
            if (!_cache.TryGetValue(MemoryCacheConst.MicroService, out services))
            {
                return BadRequest();
            }
            return Ok(services);
        }

        private async Task SyncProducts(string uri)
        {
            List<Product> productCache;
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync($"{uri}/api/products");
                result.EnsureSuccessStatusCode();
                string content = await result.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                if (!_cache.TryGetValue(MemoryCacheConst.Product, out productCache))
                {
                    productCache = new List<Product>();
                    productCache.AddRange(products);
                }
                productCache.AddRange(products);
                _cache.Set(MemoryCacheConst.Product, productCache, cacheEntryOptions);
            }
        }

        private void RemoveRangeProducts(string service)
        {
            List<Product> productCache;
            if (_cache.TryGetValue(MemoryCacheConst.Product, out productCache))
            {
                productCache.RemoveAll(x => x.Service.Equals(service));
                _cache.Set(MemoryCacheConst.Product, productCache, cacheEntryOptions);
            }
        }
    }
}
