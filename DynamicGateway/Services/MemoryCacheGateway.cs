using Microsoft.Extensions.Caching.Memory;

namespace DynamicGateway.Services
{
    public class MemoryCacheGateway
    {
        public MemoryCache Cache { get; private set; }
        public MemoryCacheGateway()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
        }
    }
}
