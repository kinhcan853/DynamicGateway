using GatewayLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ServiceOne.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
        protected List<Product> products = new List<Product>()
        {
            new Product() {Id = 1,Code="GOTIT001",Service = "GOTIT" },
            new Product() {Id = 2,Code="GOTIT002",Service = "GOTIT" },
            new Product() {Id = 3,Code="GOTIT003",Service = "GOTIT" },
            new Product() {Id = 4,Code="GOTIT004",Service = "GOTIT" },
            new Product() {Id = 5,Code="GOTIT005",Service = "GOTIT" },
            new Product() {Id = 6,Code="GOTIT006",Service = "GOTIT" },
            new Product() {Id = 7,Code="GOTIT007",Service = "GOTIT" },
            new Product() {Id = 8,Code="GOTIT008",Service = "GOTIT" },
            new Product() {Id = 9,Code="GOTIT009",Service = "GOTIT" },
            new Product() {Id = 10,Code="GOTIT010",Service = "GOTIT" }
        };
    }
}
