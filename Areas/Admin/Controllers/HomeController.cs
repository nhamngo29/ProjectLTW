using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Filters;
namespace Project.Areas.Admin.Controllers
{
    [MyAuthenFilter]
    [AdminAuthorrization]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}