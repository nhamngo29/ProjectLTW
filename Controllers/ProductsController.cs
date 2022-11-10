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
        public ActionResult Index(string Search="",int? Sort=0)
        {
            List<Product> Products = DB.Products.Where(t => t.Name.Contains(Search)).ToList();
            ViewBag.Search=Search;
            if (Sort==1)
            {
                Products = Products.OrderBy(T => T.Price).ToList();
            }
            else if(Sort==2)
            {
                Products=Products.OrderByDescending(T => T.Price).ToList();
            }    
            else if(Sort==3)
            {
                Products = Products.OrderBy(T => T.Name).ToList();
            }    
            else if(Sort==4)
            {
                Products = Products.OrderByDescending(T => T.Name).ToList();
            }    
            else if(Sort==5)
            {
                Products = Products.OrderByDescending(T => T.DateCreate).ToList();
            }    
            else if(Sort==6)
            {
                Products = Products.OrderBy(T => T.DateCreate).ToList();
            }
            else if (Sort==7)
            {
                Products = Products.OrderByDescending(T => T.TotalSold).ToList();
            }  
            return View(Products);
        }
    }
}