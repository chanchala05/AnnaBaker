using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siemens.Common;
using Siemens.Model;
using Siemens.Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : BaseController
    {
        private readonly IRepository repository;
        public CalculationController(IRepository _repository)
        {
            repository = _repository;
        }
        [HttpPost]
        [Route("dicountCal")]
        public IActionResult DicountCal(DiscountModel _objModel)
        {
            ResponseModel<int> response = new ResponseModel<int>();
           
            try
            {
                var totalPrice = 0;
                totalPrice = ((_objModel.Price * _objModel.Weight) - (_objModel.Rate * (_objModel.Price * _objModel.Weight)) / 100);

                response.Data = totalPrice;
                response.IsSuccess = true;
                response.Message = "Success";
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            
            return Ok(response);
        }
    }
}
