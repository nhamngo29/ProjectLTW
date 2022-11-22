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
        [OutputCache(Duration = 1000)]//Thời gian để chờ load lại trang
        public ActionResult Index(string Search="",int? Sort=0,int? ProType=0,int? CaregoryID=0,int page=1)
        {
            List<Product> Products = DB.Products.Where(t => t.Name.Contains(Search)).ToList();
            ViewBag.Search=Search;
            switch (Sort)
            {
                case 1:
                    Products = Products.OrderBy(T => T.Price).ToList();
                    break;
                case 2:
                    Products = Products.OrderByDescending(T => T.Price).ToList();
                    break;
                case 3:
                    Products = Products.OrderBy(T => T.Name).ToList();
                    break;
                case 4:
                    Products = Products.OrderByDescending(T => T.Name).ToList();
                    break;
                case 5:
                    Products = Products.OrderByDescending(T => T.DateCreate).ToList();
                    break;
                case 6:
                    Products = Products.OrderBy(T => T.DateCreate).ToList();
                    break;
                case 7:
                    Products = Products.OrderByDescending(T => T.TotalSold).ToList();
                    break;
                case 8:
                    Products = Products.OrderByDescending(T => T.TotalSold).ToList();
                    break;
            }
            if (CaregoryID!=0)
            {
                Products = Products.Where(t => t.ProductType.CategoryID==CaregoryID).ToList();
            }
            if (ProType!=0)
            {
                Products = Products.Where(t => t.ProductTypeID == ProType).ToList();
            }
            //Paging
            ViewBag.Sort=Sort;
            int NoOfrecordPerPage = 8;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Products.Count) / Convert.ToDouble(NoOfrecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfrecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            Products = Products.Skip(NoOfRecordToSkip).Take(NoOfrecordPerPage).ToList();
            return View(Products);
        }
        [OutputCache(Duration = 1000)]//Thời gian để chờ load lại trang
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
        //public ActionResult AddToCard()
        //{

        //}
    }
}