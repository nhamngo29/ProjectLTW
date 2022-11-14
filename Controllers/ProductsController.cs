using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Filters;
namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        ShopDBContext DB=new ShopDBContext();
        // GET: Products
        [MyActionFilters]
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
        public ActionResult Detail(string id)
        {
            Product product=DB.Products.Find(id);
            ViewBag.AllImg = DB.Imges.Where(t => t.ProductId == id).ToList();
            if (product!=null)
            {
                if (product.Promotion>0)
                {
                    ViewBag.Price = product.Price *(1 - product.Promotion * 0.01);
                }
                else
                {
                    ViewBag.Price = product.Price;
                }    
            }
            ViewBag.ProductsSame = DB.Products.Where(t => t.ProductType.Id == product.ProductTypeID).ToList();
            ViewBag.Property = DB.Properties.Where(t=>t.ProductId==id).ToList();
            return View(product);
        }
    }
}