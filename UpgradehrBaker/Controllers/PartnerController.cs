//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using UpgradehrBaker.Common;
using UpgradehrBaker.Model;
using UpgradehrBaker.Models;
using UpgradehrBaker.Reposetory;

namespace UpgradehrBaker.Controllers
{
    [ApiController]
    [Route("api/partner/")]
    public class PartnerController : ControllerBase
    {
        private readonly IRepository repository;
        public PartnerController(IRepository _repository)
        {
            repository = _repository;
        }
        [HttpPost]
        [Route("add")]
        public ResponseModel<PartnerModel> Add(PartnerModel model)
        {
            ResponseModel<PartnerModel> response = new ResponseModel<PartnerModel>();
            var data = repository.IsPartenerExist(model.Email);
            if (!data)
            {
                Partner user = new Partner();
                user.Name = model.Name;
                user.Password = model.Password;
                user.Email = model.Email;
                repository.AddPartener(user);
                model.Token = GenerateJWT.GenerateToken(model);

                response.Data = model;
                response.IsSuccess = true;
                response.Message = "Success";
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = "Email already exist";
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }

            return response;
        }
        [HttpPost]
        [Route("login")]
        public ResponseModel<PartnerModel> Login(Login model)
        {
            ResponseModel<PartnerModel> response = new ResponseModel<PartnerModel>();
            PartnerModel user = new PartnerModel();
            var data = repository.GetPartenerByEmail(model.Email);
            if (data != null && data.Password == model.Passworrd)
            {
                user.Id = data.Id;
                user.Name = data.Name;
                user.Email = data.Email;
                user.Token = GenerateJWT.GenerateToken(user);

                response.Data = user;
                response.IsSuccess = true;
                response.Message = "Success";
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = "Email or password not match";
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }

            return response;
        }
        
        
        [HttpGet]
        [Route("{id}")]
        public ResponseModel<Partner> Get(int id)
        {
            ResponseModel<Partner> response = new ResponseModel<Partner>();
            PartnerModel user = new PartnerModel();
            var data = repository.GetPartener(id);
            response.Data = data;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        


    }
}
