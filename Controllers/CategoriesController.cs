using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        ShopDBContext DB=new ShopDBContext();
        public ActionResult Index()
        {
            List<Category> categories=DB.Categories.ToList();
            return View(categories);
        }
    }
}