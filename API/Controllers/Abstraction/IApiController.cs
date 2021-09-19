using API.Models;
using Entities.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Abstraction
{
    public interface IApiController<TEntity> where TEntity : BaseEntity, IEntity
    {
        Task<ActionResult<ApiResult<TEntity>>> Get();

        Task<ActionResult<ApiResult<TEntity>>> Get(long id);

        Task<ActionResult<ApiResult<TEntity>>> GetBy(string propertyName, string propertyValue);

        Task<ActionResult<ApiResult<TEntity>>> Post(TEntity entity);

        Task<ActionResult<ApiResult<TEntity>>> Put(long id, TEntity entity);

        Task<ActionResult<ApiResult<TEntity>>> Delete(long id);

        Task<ActionResult<ApiResult<TEntity>>> DeleteRange(List<TEntity> entities);
    }
}