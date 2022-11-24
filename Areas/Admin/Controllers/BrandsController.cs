using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        ShopDBContext db = new ShopDBContext();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            var item = db.Brands.ToList();
            return View(item);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand p)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<Brand> Brands)
        {
            foreach (Brand item in Brands)
            {
                Brand oldBrand = db.Brands.Find(item.Id);
                oldBrand.Name= item.Name;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Brands");
        }
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            var checkBrand = db.Brands.FirstOrDefault(x => x.Id == id);
            if (checkBrand != null)
            {
                db.Brands.Remove(checkBrand);
                db.SaveChanges();
                code = new { Success = true, msg = "", code = 1, count = db.Categories.Count() };
            }
            return Json(code);
        }
    }
}