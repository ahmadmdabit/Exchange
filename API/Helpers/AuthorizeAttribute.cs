using API.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (SkipAuthorization(context)) return;

            var Unauthoried = context.HttpContext.Items["User"] == null;
            if (!Unauthoried && context.HttpContext.Items["User"] is Task<User> user && user == null)
            {
                user.Wait();
                Unauthoried = user == null;
            }
            if (Unauthoried)
            {
                // not logged in
                context.Result = new JsonResult(new ApiResult(false, null, new UnauthorizedResult().StatusCode, "Unauthorized"))
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }

        private static bool SkipAuthorization(AuthorizationFilterContext context)
        {
            if (context == null) return false;
            return context.ActionDescriptor.EndpointMetadata.Any(x => x.GetType() == typeof(AllowAnonymousAttribute));
        }
    }
}