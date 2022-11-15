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
namespace Project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Project.Identity.AppDBContext db = new AppDBContext();
        public ActionResult Regisster()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regisster(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                var appDBContext=new AppDBContext();
                var userStore = new AppUserStore(appDBContext);
                var userManager = new AppUserManager(userStore);
                var passwdHash=Crypto.HashPassword(vm.Password);
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
                ModelState.AddModelError("New error","Invalid data");
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
            if (user!=null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and password");
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            var authenManager=HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Profile()
        {
            string curentUserID = User.Identity.GetUserId();
            AppUser curentUser=db.Users.Find(curentUserID);
            return View(curentUser);
        }
    }
}