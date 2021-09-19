using API.Controllers.Abstraction;
using API.Helpers;
using BLL.Abstraction;
using Common.Helpers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExchangeInfosController : BaseApiController<ExchangeInfo>
    {
        private readonly IDistributedCache _distributedCache;

        public ExchangeInfosController(IBusiness<ExchangeInfo> _business, ILogger<BaseApiController<ExchangeInfo>> logger, IDistributedCache distributedCache) : base(_business, logger)
        {
            this._distributedCache = distributedCache;
        }

        //[AllowAnonymous]
        [HttpGet("redis")]
        public async Task<IActionResult> GetUsingRedisCache()
        {
            var dataList = await RedisHelper.GetRedisData<List<ExchangeInfo>>("dataList");
            if (dataList == null || dataList.Count == 0)
            {
                dataList = await this._business.Get().ConfigureAwait(false);
                await RedisHelper.SetRedisData("dataList", dataList);
            }
            return Ok(dataList);
        }
    }
}