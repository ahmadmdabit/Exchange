using Entities.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models
{
    public class ApiResult
    {
        public bool Status { get; set; }
        public object Data { get; set; }

        public ErrorResult Error { get; set; }

        public ApiResult()
        {
        }

        public ApiResult(bool status, object data, ErrorResult error)
        {
            this.Status = status;
            this.Data = data;
            this.Error = error;
        }

        public ApiResult(bool status, object data, int errorCode, string errorMessage)
        {
            this.Status = status;
            this.Data = data;
            this.Error = new ErrorResult(errorCode, errorMessage);
        }
    }

    public class ApiResult<TEntity> where TEntity : BaseEntity, IEntity
    {
        public bool Status { get; set; }
        public TEntity Data { get; set; }
        public ErrorResult Error { get; set; }

        public ApiResult()
        {
        }

        public ApiResult(bool status, TEntity data, ErrorResult error)
        {
            this.Status = status;
            this.Data = data;
            this.Error = error;
        }

        public ApiResult(bool status, TEntity data, int errorCode, string errorMessage)
        {
            this.Status = status;
            this.Data = data;
            this.Error = new ErrorResult(errorCode, errorMessage);
        }
    }

    public class ApiResultList<TEntity> where TEntity : BaseEntity, IEntity
    {
        public bool Status { get; set; }
        public List<TEntity> Data { get; set; }
        public ErrorResult Error { get; set; }

        public ApiResultList()
        {
        }

        public ApiResultList(bool status, List<TEntity> data, ErrorResult error)
        {
            this.Status = status;
            this.Data = data;
            this.Error = error;
        }

        public ApiResultList(bool status, List<TEntity> data, int errorCode, string errorMessage)
        {
            this.Status = status;
            this.Data = data;
            this.Error = new ErrorResult(errorCode, errorMessage);
        }
    }

    public class RequestValidationApiResult : ApiResult, IActionResult
    {
        public RequestValidationApiResult()
        {
            this.Status = false;
            this.Data = null;
            this.Error = new ErrorResult(400, "Request Validation Error: A non-empty request body is required.");
        }

        public RequestValidationApiResult(bool status, object data, ErrorResult error) : base(status, data, error)
        {
        }

        public RequestValidationApiResult(bool status, object data, int errorCode, string errorMessage) : base(status, data, errorCode, errorMessage)
        {
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this) { StatusCode = StatusCodes.Status200OK }.ExecuteResultAsync(context).ConfigureAwait(false);
        }
    }
}