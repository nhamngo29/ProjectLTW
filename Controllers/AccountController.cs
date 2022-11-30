using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.ViewModel;
using Project.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Project.Models;
using Project.Filters;
namespace Project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Project.Identity.AppDBContext db = new AppDBContext();
        ShopDBContext DB = new ShopDBContext();

        public ActionResult Regisster()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regisster(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                var appDBContext = new AppDBContext();
                var userStore = new AppUserStore(appDBContext);
                var userManager = new AppUserManager(userStore);
                var passwdHash = Crypto.HashPassword(vm.Password);
                var user = new AppUser()
                {
                    Email = vm.Email,
                    UserName = vm.UserName,
                    PasswordHash = passwdHash,
                    City = vm.City,
                    BirthDay = vm.DateOfBirth,
                    FullName = vm.FullName,
                    Address = vm.Address,
                    PhoneNumber = vm.Mobile
                };

                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("New error", "Invalid data");
                return View();
            }

        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LoginVm vm)
        {
            var appDBContext = new AppDBContext();
            var userStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(vm.UserName, vm.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and password");
                return View();
            }

        }
        [MyAuthenFilter]
        public ActionResult LogOut()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [MyAuthenFilter]
        public ActionResult Profile()
        {

            string curentUserID = User.Identity.GetUserId();
            AppUser curentUser = db.Users.Where(t=>t.Id== curentUserID).FirstOrDefault();
            List<Order> Orders = db.Orders.Where(t => t.IdUser==curentUserID).ToList();
            ViewBag.Orders = Orders;
            return View(curentUser);
        }
        [MyAuthenFilter]
        public ActionResult ShowCount()
        {
            string curentUserID = User.Identity.GetUserId();
            List<Identity.Cart> Carts = db.Carts.Where(t => t.IdUser == curentUserID).ToList();
            if (Carts!=null)
            {
                return Json(new {Count=Carts.Count()},JsonRequestBehavior.AllowGet);
            }
            return Json(new {Count = 0}, JsonRequestBehavior.AllowGet);
        }
        [MyAuthenFilter]
        public ActionResult Cart()
        {
            string curentUserID = User.Identity.GetUserId();
            List<ShoppingCartItem> products=new List<ShoppingCartItem>();
            
            Product product = new Product();
            List<Identity.Cart> Carts = db.Carts.Where(t => t.IdUser == curentUserID).ToList();
            double TongTien = 0;
            foreach (var item in Carts)
            {
                ShoppingCartItem x = new ShoppingCartItem();
                product = DB.Products.Find(item.IdProduct);
                x.ProductId = product.ProductId;
                x.Price =item.Price;
                x.Name =(string)product.Name;
                x.img = product.ImgeMain;
                x.Quantity = item.Quantity;
                x.TotalPrice = x.Quantity * x.Price;
                products.Add(x);
                TongTien += x.TotalPrice;
            }
            ViewBag.TongTien = TongTien;
            return View(products);
        }
        [HttpPost]
        [MyAuthenFilter]
        public ActionResult AddToCart(string id, int Quantity,float price)
        {
            string curentUserID = User.Identity.GetUserId();
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            var Cart = db.Carts.FirstOrDefault(x => x.IdUser == curentUserID &&x.IdProduct==id);
            Cart Carts = new Cart();
            Carts.IdProduct = id;
            Carts.IdUser = curentUserID;
            Carts.Quantity = Quantity;
            Carts.Price = price;
            if (Cart == null)
            {
                db.Carts.Add(Carts);
                db.SaveChanges();
                code = new { Success = true, msg = "Them san pham vao gio hang thanh cong", code = 1, count = db.Carts.Count() };
            }
            else
            {
                Quantity +=  1;
                Cart.Quantity=Quantity;
                db.SaveChanges();
            }    
            return Json(code);
        }

        public ActionResult Partital_Item_Cart()
        {
            return PartialView();
        }    
        [HttpPost]
        [MyAuthenFilter]
        public ActionResult Delete(string id)
        {
            string curentUserID = User.Identity.GetUserId();
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            var Cart = db.Carts.Where(t=>t.IdUser==curentUserID);
            
            if (Cart!=null)
            {
                var checkProducts = db.Carts.FirstOrDefault(x => x.IdProduct == id);
                if (checkProducts!=null)
                {
                    db.Carts.Remove(checkProducts);
                    db.SaveChanges();
                    code = new { Success = true, msg = "", code = 1, count = db.Carts.Count() };
                }    
            }
            return Json(code);
        }
        
    }
}