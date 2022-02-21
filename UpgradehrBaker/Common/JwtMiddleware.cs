using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradehrBaker.Common
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _configuration;
        //private ICustomerService customerService;
        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this._next = next;
            this._configuration = configuration;
        }

        //public async Task Invoke(HttpContext context, ICustomerService customerService)
        //{
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        //    if (token != null)
        //        attachUserToContext(context, customerService, token);

        //    await _next(context);
        //}

        //private void attachUserToContext(HttpContext context, ICustomerService customerService, string token)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(SiteKeys.ScretKey);
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //            ClockSkew = TimeSpan.Zero
        //        }, out SecurityToken validatedToken);

        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //        var userId = jwtToken.Claims.First(x => x.Type == "Id").Value;

        //        // attach user to context on successful jwt validation
        //        context.Items["Customer"] = customerService.GetById(Convert.ToInt32(userId));
        //    }
        //    catch (Exception ex)
        //    {
        //        //LoggingRepository.SaveException(ex);
        //    }
        //}
    }
}
