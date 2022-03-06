using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Siemens.Model;

namespace Siemens.Common
{
    public class GenerateJWT
    {
        public static string GenerateToken(Login model)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SiteKeys.ScretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserName", model.UserName.ToString()),
                    new Claim(ClaimTypes.Name,model.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),// generate token that is valid for 1 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
