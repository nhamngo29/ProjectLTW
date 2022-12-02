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
        // GET: Category
        ShopDBContext DB=new ShopDBContext();
        public ActionResult Category()
        {
            List<Category> ListCategories=DB.Categories.ToList();
            ViewBag.ProductTypes = DB.ProductTypes.ToList();
            return View(ListCategories);
        }
    }
}