using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        ShopDBContext DB=new ShopDBContext();
        // GET: Products
        public ActionResult Index()
        {
            List<Product> Products=DB.Products.ToList();
            return View(Products);
        }
    }
}