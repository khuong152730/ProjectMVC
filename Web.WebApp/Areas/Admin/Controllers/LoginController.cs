using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.WebApp.Areas.Admin.ViewModel;

namespace Web.WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
     
     


    }
}
