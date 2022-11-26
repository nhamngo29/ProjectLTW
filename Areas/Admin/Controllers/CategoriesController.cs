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
    public class CategoriesController : Controller
    {
        ShopDBContext db = new ShopDBContext();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            var item = db.Categories.ToList();
            return View(item);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category p)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<Category> Categories)
        {
            if (ModelState.IsValid)
            {
                foreach (Category item in Categories)
                {
                    Category oldCategory = db.Categories.Find(item.Id);
                    oldCategory.Name = item.Name;

                }
                db.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }
            return RedirectToAction("Index", "Categories");
        }
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            var checkCategory = db.Categories.FirstOrDefault(x => x.Id == id);
            if (checkCategory != null)
            {
                db.Categories.Remove(checkCategory);
                db.SaveChanges();
                code = new { Success = true, msg = "", code = 1, count = db.Categories.Count() };
            }
            return Json(code);
        }
    }
}