using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Regisster()
        {
            return View();
        }
    }
}