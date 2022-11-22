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
        public ActionResult LogOut()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Profile()
        {
            string curentUserID = User.Identity.GetUserId();
            AppUser curentUser = db.Users.Find(curentUserID);
            return View(curentUser);
        }
        public ActionResult Cart()
        {
            string curentUserID = User.Identity.GetUserId();
            List<Identity.Cart> Carts = db.Carts.Where(t => t.IdUser == curentUserID).ToList();
            return View(Carts);
        }
        [HttpPost]
        public ActionResult AddToCart(string id, int Quantity)
        {
            var code = new { Success = false, msg = "", code = -1 ,count=0};
            var checkProduct = DB.Products.FirstOrDefault(x => x.ProductId == id);
            if (checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                
                if (cart == null)
                {
                    cart=new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductId = checkProduct.ProductId,
                    Name = checkProduct.Name,
                    Price = (double)checkProduct.Price,
                    img = checkProduct.ImgeMain,
                    Quantity = Quantity
                };
                item.Price = (double)checkProduct.Price;
                if (checkProduct.Promotion > 0)
                {
                    item.Price = (double)(checkProduct.Price * (1 - checkProduct.Promotion * 0.01));
                }
                item.TotalPrice = (double)(item.Quantity * checkProduct.Price);
                cart.AddToCart(item, Quantity);
                Session["Cart"] = cart;
                code=new { Success = true, msg = "Them san pham vao gio hang thanh cong", code = 1 ,count=cart.items.Count()}; 
            }
            return Json(code);
        }
    }
}