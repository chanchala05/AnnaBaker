using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.Controllers
{
    public class BaseController : Controller
    {
        public int CurrentUser
        {
            get { return Convert.ToInt32(this.User.Claims.First(i => i.Type == "Id").Value); }
        }
    }
}
