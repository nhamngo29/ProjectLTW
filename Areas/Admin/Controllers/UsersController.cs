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
            User = app;
            DB.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
    }
}