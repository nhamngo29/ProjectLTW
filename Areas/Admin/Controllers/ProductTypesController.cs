using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Areas.Admin.Controllers
{
    public class ProductTypesController : Controller
    {
        // GET: Admin/ProductType
        ShopDBContext DB=new ShopDBContext();
        public ActionResult Index()
        {
            List<ProductType> ProductTypes=DB.ProductTypes.ToList();
            ViewBag.Categories=DB.Categories.ToList();
            return View(ProductTypes);
        }
    }
}