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
    [Route("api/product/")]
    public class ProductsController : BaseController
    {
        private readonly IRepository repository;
        public ProductsController(IRepository _repository)
        {
            repository = _repository;
        }
        [HttpPost]
        [Route("getOffer")]
        public ResponseModel<List<TblOffer>> GetOffer()
        {
            ResponseModel<List<TblOffer>> response = new ResponseModel<List<TblOffer>>();
            var data = repository.GetOffer(CurrentUser);

            response.Data = data;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        [HttpPost]
        [Route("addOffer")]
        public ResponseModel<string> AddOffer(OfferModel model)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            TblOffer offer = new TblOffer();
            offer.PartnerId = model.PartnerId;
            offer.ProductId = model.ProductId;
            offer.ProductOffer = model.offer;

            repository.AddOffer(offer);

            response.Data = null;
            response.IsSuccess = true;
            response.Message = "Offer add successfully";
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        [HttpPut]
        [Route("updateOffer")]
        public ResponseModel<string> UpdateOffer(OfferModel model)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            TblOffer offer = new TblOffer();
            offer.PartnerId = model.PartnerId;
            offer.ProductId = model.ProductId;
            offer.ProductOffer = model.offer;

            repository.UpdateOffer(offer);

            response.Data = null;
            response.IsSuccess = true;
            response.Message = "Offer updated successfully";
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        [HttpDelete]
        [Route("deleteOffer")]
        public ResponseModel<string> deleteOffer(int id)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            repository.DeleteOffer(id);

            response.Data = null;
            response.IsSuccess = true;
            response.Message = "Offer deleted successfully";
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        [HttpGet]
        [Route("getOrderList")]
        public ResponseModel<List<TblOrder>> GetOrderList()
        {
            ResponseModel<List<TblOrder>> response = new ResponseModel<List<TblOrder>>();
            var data = repository.GetOrderList(CurrentUser);
            response.Data = data;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }


    }
}
