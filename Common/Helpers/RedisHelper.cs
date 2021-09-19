using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class RedisHelper
    {
        public static IDistributedCache DistributedCache;

        public static async Task<byte[]> GetRedisData(string cacheKey)
        {
            return await DistributedCache.GetAsync(cacheKey);
        }

        public static async Task<string> GetRedisDataSerialized(string cacheKey)
        {
            if (DistributedCache == null) throw new NullReferenceException($"Property {nameof(DistributedCache)} must be initialized before");
            string serializedDataList = string.Empty;
            var redisCustomerList = await DistributedCache.GetAsync(cacheKey);
            if (redisCustomerList != null) serializedDataList = Encoding.Unicode.GetString(redisCustomerList);
            return serializedDataList;
        }

        public static async Task<T> GetRedisData<T>(string cacheKey)
        {
            return JsonConvert.DeserializeObject<T>(await GetRedisDataSerialized(cacheKey));
        }

        public static async Task SetRedisData<T>(string cacheKey, T dataList)
        {
            if (DistributedCache == null) throw new NullReferenceException($"Property {nameof(DistributedCache)} must be initialized before");
            var serializedDataList = JsonConvert.SerializeObject(dataList);
            var redisCustomerList = Encoding.Unicode.GetBytes(serializedDataList);
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            await DistributedCache.SetAsync(cacheKey, redisCustomerList, options);
        }
    }
}