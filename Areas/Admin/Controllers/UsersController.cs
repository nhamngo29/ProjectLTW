using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.Identity;
namespace Project.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/User
        AppDBContext DB=new AppDBContext();

        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.PageSize = pageSize;
            var Users=DB.Users.OrderByDescending(x => x.UserName).ToList();
          
            return View(Users.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(string Id)
        {
            var User=DB.Users.Find(Id);
            ViewBag.Roles=DB.Roles.ToList();
            return View(User);
        }
        [HttpPost]
        public ActionResult Edit(AppUser app)
        {
            AppUser User = DB.Users.Where(t=>t.Id==app.Id).FirstOrDefault();
            User.FullName=app.FullName;
            User.Email=app.Email;
            User.IsActive=app.IsActive;
            DB.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        public ActionResult IsActive(string id)
        {
            var item = DB.Users.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return Json(new { success = true, isAcive = item.IsActive });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult Remove(string id)
        {
            var item = DB.Users.Find(id);
            if (item!=null)
            {
                DB.Users.Remove(item);
                DB.SaveChanges();
                return Json(new { success = true }) ;
            }
            return Json(new { success = false });
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}