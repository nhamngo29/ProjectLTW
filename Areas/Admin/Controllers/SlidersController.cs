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
    public class SlidersController : Controller
    {
        ShopDBContext DB=new ShopDBContext();
        // GET: Admin/Sliders
        public ActionResult Index()
        {
            List<Slide> Slides=DB.Slides.ToList();
            return View(Slides);
        }
        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = DB.Slides.Find(id);
            if (item!=null)
            {
                item.Active = !item.Active;
                DB.Entry(item).State =System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return Json(new { success = true ,isAcive=item.Active});
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            var checkOut = DB.Slides.FirstOrDefault(x => x.Id == id);
            if (checkOut != null)
            {
                DB.Slides.Remove(checkOut);
                DB.SaveChanges();
                code = new { Success = true, msg = "", code = 1, count = DB.Categories.Count() };
            }
            return Json(code);
        }    

        public ActionResult Create()
        {
            return View();
        }
    }
}