//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using Siemens.Common;
using Siemens.Model;
using Siemens.Models;
using Siemens.Reposetory;

namespace Siemens.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IRepository repository;
        public AccountController(IRepository _repository)
        {
            repository = _repository;
        }
   
        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login model)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            var data = repository.GetUser(model.UserName);
            if (data != null && data.Password == model.Passworrd)
            {
                var Token = GenerateJWT.GenerateToken(model);
                response.Data = Token;
                response.IsSuccess = true;
                response.Message = "Success";
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = "User name or password not match";
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return Ok(response);
        }
        

        


    }
}
