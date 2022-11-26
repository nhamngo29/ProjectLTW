using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Filters;
namespace Project.Areas.Admin.Controllers
{
    [MyAuthenFilter]
    [AdminAuthorrization]
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
        public ActionResult Create()
        {
            ViewBag.Categories= DB.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                DB.ProductTypes.Add(productType);
                DB.SaveChanges();
                return RedirectToAction("Index","ProductTypes");
            }
            return View(productType);
        }
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            var checkOut = DB.ProductTypes.FirstOrDefault(x => x.Id == id);
            if (checkOut != null)
            {
                DB.ProductTypes.Remove(checkOut);
                DB.SaveChanges();
                code = new { Success = true, msg = "", code = 1, count = DB.Categories.Count() };
            }
            return Json(code);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<ProductType> ProductTypes)
        {
            if (ModelState.IsValid)
            {
                foreach (ProductType item in ProductTypes)
                {
                    ProductType oldProductType = DB.ProductTypes.Find(item.Id);
                    oldProductType.Id = item.Id;
                    oldProductType.Name = item.Name;
                    oldProductType.CategoryID=item.CategoryID;
                }
                DB.SaveChanges();
            }
            return RedirectToAction("Index", "Producttypes");
        }
    }
}