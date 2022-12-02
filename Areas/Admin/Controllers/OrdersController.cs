using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Project.Identity;
using Project.Models;
using Microsoft.AspNet.Identity;

namespace Project.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Admin/Orders
        ShopDBContext DB = new ShopDBContext();
        AppDBContext AppDB = new AppDBContext();
        public ActionResult Index(int? Sort = 0, int page = 1)
        {
            List<Order> Orders = AppDB.Orders.ToList();
            switch (Sort)
            {
                case 1:
                    Orders = Orders.OrderBy(T => T.TotalPrice).ToList();
                    break;
                case 2:
                    Orders = Orders.OrderByDescending(T => T.TotalPrice).ToList();
                    break;
            }
            int NoOfrecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Orders.Count) / Convert.ToDouble(NoOfrecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfrecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            Orders = Orders.Skip(NoOfRecordToSkip).Take(NoOfrecordPerPage).ToList();
            return View(Orders);
        }
        public ActionResult Detail(int id)
        {
            Order s = AppDB.Orders.Where(t => t.Id == id).FirstOrDefault();
            ViewBag.Order = s;
            ViewBag.User = AppDB.Users.Find(s.IdUser);
            List<OrderDetail> orderDetail = AppDB.OrderDetails.Where(t => t.IdOrder == id).ToList();

            return View(orderDetail);
        }
        [HttpPost]
        public ActionResult Edit(List<Order> orders)
        {
            foreach (var item in orders)
            {
                Order s = AppDB.Orders.Where(t => t.Id == item.Id).Where(t => t.IdUser == item.IdUser).FirstOrDefault();
                s.Status=item.Status;
            }
            DB.SaveChanges();
            return RedirectToAction("Index","Orders");
        }
    }
}