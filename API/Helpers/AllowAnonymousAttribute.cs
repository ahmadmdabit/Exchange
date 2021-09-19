using Microsoft.AspNetCore.Mvc.Authorization;
using System;

namespace API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute, IAllowAnonymousFilter
    {
    }
}