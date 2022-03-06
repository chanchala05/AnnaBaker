using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Siemens.Models;
using Siemens.Reposetory;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Common
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _configuration;
        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this._next = next;
            this._configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IRepository _repo)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, _repo, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IRepository _repo, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SiteKeys.ScretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var UserName = jwtToken.Claims.First(x => x.Type == "UserName").Value;

                // attach user to context on successful jwt validation
                context.Items["TblUser"] = _repo.GetUser(UserName);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
