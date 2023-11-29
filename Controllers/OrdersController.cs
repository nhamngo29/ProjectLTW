using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Identity;
using Microsoft.AspNet.Identity;
namespace Project.Controllers
{
    public class OrdersController : Controller
    {
        AppDBContext db=new AppDBContext();
        // GET: Order
        [HttpPost]
        public ActionResult Order(float price)
        {
            Order Orderr = new Order();
            string curentUserID = User.Identity.GetUserId();
            List<Cart> Carts = db.Carts.Where(t => t.IdUser == curentUserID).ToList();
            var code = new { Success = false};
            if (Carts!=null && Carts.Any())
            {
                Orderr.DateBooking = DateTime.Now;
                Orderr.IdUser = curentUserID;
                Orderr.Total = price;
                Orderr.Status = 0;
                if (Orderr.Total<500000)
                {
                    Orderr.Ship = 30000;
                }
                Orderr.TotalPrice = price+Orderr.Ship;
                db.Orders.Add(Orderr);
                db.SaveChanges();
                foreach (var item in Carts)
                {
                    OrderDetail Detail = new OrderDetail();
                    double ThanhTien = item.Quantity * item.Price;
                    Detail.IdOrder = Orderr.Id;
                    Detail.IdProductt = item.IdProduct;
                    Detail.Count = item.Quantity;
                    Detail.Price = item.Price;
                    Detail.Thanhtien = ThanhTien;
                    db.OrderDetails.Add(Detail);
                    db.Carts.Remove(item);
                }
                
                db.SaveChanges();
                code = new { Success = true};
            }
            return Json(code);
        }
        public ActionResult OrderSucces()
        {
            return View();
        }
        public ActionResult OrderDetail(int id)
        {
            ViewBag.Order=db.Orders.Where(t=>t.Id==id).FirstOrDefault();
            List<OrderDetail> OrderDetails=db.OrderDetails.Where(t=>t.IdOrder == id).ToList(); 
            return View(OrderDetails);
        }
    }
}