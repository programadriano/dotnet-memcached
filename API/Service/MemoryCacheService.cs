using Enyim.Caching;
using System.Reflection.PortableExecutable;

namespace API.Service
{
    public class MemoryCacheService : ICacheService
    {

        private readonly IMemcachedClient _cache;
        private const int cacheSeconds = 600;

        public MemoryCacheService(IMemcachedClient cache)
        {
            _cache = cache; 
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set(string key, object content)
        {
            _cache.Add(key, content, cacheSeconds);
        }
    }
}
