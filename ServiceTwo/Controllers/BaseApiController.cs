using GatewayLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ServiceTwo.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
        protected List<Product> products = new List<Product>()
        {
            new Product() {Id = 11,Code="URBOX001",Service = "URBOX" },
            new Product() {Id = 12,Code="URBOX002",Service = "URBOX" },
            new Product() {Id = 13,Code="URBOX003",Service = "URBOX" },
            new Product() {Id = 14,Code="URBOX004",Service = "URBOX" },
            new Product() {Id = 15,Code="URBOX005",Service = "URBOX" },
            new Product() {Id = 16,Code="URBOX006",Service = "URBOX" },
            new Product() {Id = 17,Code="URBOX007",Service = "URBOX" },
            new Product() {Id = 18,Code="URBOX008",Service = "URBOX" },
            new Product() {Id = 19,Code="URBOX009",Service = "URBOX" },
            new Product() {Id = 20,Code="URBOX010",Service = "URBOX" }
        };
    }
}
