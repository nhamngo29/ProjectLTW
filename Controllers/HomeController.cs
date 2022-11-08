using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ShopDBContext DB=new ShopDBContext();
        public ActionResult Index()
        {
            List<Slide> Slides=DB.Slides.ToList();
            ViewBag.Slides=Slides;
            ViewBag.Length=Slides.Count;
            return View();
        }
    }
}