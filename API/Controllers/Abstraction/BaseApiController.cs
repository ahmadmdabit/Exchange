using API.Models;
using BLL.Abstraction;
using Entities.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Abstraction
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public abstract class BaseApiController<TEntity> : ControllerBase, IApiController<TEntity> where TEntity : BaseEntity, IEntity
    {
        protected readonly IBusiness<TEntity> _business;
        protected readonly ILogger _logger;

        protected BaseApiController(IBusiness<TEntity> _business, ILogger<BaseApiController<TEntity>> logger)
        {
            this._business = _business;
            this._logger = logger;
        }

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> Get()
        {
            this._logger.LogInformation($"[Get]");
            return Ok(new ApiResultList<TEntity>(true, await this._business.Get().ConfigureAwait(false), null));
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> Get(long id)
        {
            this._logger.LogInformation($"[Get:{id}]");
            var entity = await this._business.Get(id).ConfigureAwait(false);
            if (entity != null)
            {
                return Ok(new ApiResult<TEntity>(true, entity, null));
            }
            return this.NotFoundApi();
        }

        // GET: api/[controller]/by/id/5
        [HttpGet("by/{propertyName}/{propertyValue}")]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> GetBy([FromRoute] string propertyName, [FromRoute] string propertyValue)
        {
            this._logger.LogInformation($"[Get:by/{propertyName}/{propertyValue}]");
            var entities = await this._business.Get(propertyName, propertyValue).ConfigureAwait(false);
            return Ok(new ApiResultList<TEntity>(true, entities, null));
        }

        // GET: api/[controller]/by/id/5/name/test
        [HttpGet("by/{property1Name}/{property1Value}/{property2Name}/{property2Value}")]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> GetBy(
            [FromRoute] string property1Name, [FromRoute] string property1Value, [FromRoute] string property2Name, [FromRoute] string property2Value)
        {
            this._logger.LogInformation($"[Get:by/{property1Name}/{property1Value}/{property2Name}/{property2Value}]");
            var entities = await this._business.Get(property1Name, property1Value, property2Name, property2Value).ConfigureAwait(false);
            return Ok(new ApiResultList<TEntity>(true, entities, null));
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> Post([FromBody] TEntity entity)
        {
            //return null;
            this._logger.LogInformation($"[Post] {JsonConvert.SerializeObject(entity)}");
            var resultEntity = await this._business.Add(entity).ConfigureAwait(false);
            if (resultEntity != null)
            {
                return Ok(new ApiResult<TEntity>(true, resultEntity, null));
            }
            return this.BadRequestApi();
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> Put(long id, [FromBody] TEntity entity)
        {
            this._logger.LogInformation($"[Put:{id}] {JsonConvert.SerializeObject(entity)}");
            var resultEntity = await this._business.Update(id, entity).ConfigureAwait(false);
            if (resultEntity != null)
            {
                return Ok(new ApiResult<TEntity>(true, resultEntity, null));
            }
            return this.BadRequestApi();
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> Delete(long id)
        {
            this._logger.LogInformation($"[Delete:{id}]");
            var resultEntity = await this._business.Delete(id).ConfigureAwait(false);
            if (resultEntity != null)
            {
                return Ok(new ApiResult<TEntity>(true, resultEntity, null));
            }
            return this.NotFoundApi();
        }

        // DELETE: api/[controller]
        [HttpDelete]
        public virtual async Task<ActionResult<ApiResult<TEntity>>> DeleteRange([FromBody] List<TEntity> entities)
        {
            this._logger.LogInformation($"[DeleteRange:{JsonConvert.SerializeObject(entities)}]");
            var resultEntities = await this._business.DeleteRange(entities).ConfigureAwait(false);
            if (resultEntities?.Count > 0)
            {
                return Ok(new ApiResultList<TEntity>(true, resultEntities, null));
            }
            return this.NotFoundApi();
        }

        protected virtual ActionResult<ApiResult<TEntity>> NotFoundApi(string message = null)
        {
            this._logger.LogInformation("NotFound");
            return Ok(new ApiResult<TEntity>(false, null, new NotFoundResult().StatusCode, message ?? "NotFound"));
        }

        protected virtual ActionResult<ApiResult<TEntity>> BadRequestApi(string message = null)
        {
            this._logger.LogInformation("BadRequest");
            return Ok(new ApiResult<TEntity>(false, null, new BadRequestResult().StatusCode, message ?? "BadRequest"));
        }
    }
}