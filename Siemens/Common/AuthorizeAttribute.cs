using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Claims;
using Siemens.Models;
using Siemens.Model;

namespace Siemens.Common.Api.Code
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        static object UserIdn;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (TblUser)context.HttpContext.Items["TblUser"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }       
    }
}
