using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Filters;
namespace Project.Areas.Admin.Controllers
{
    [MyAuthenFilter]
    [AdminAuthorrization]
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        private ShopDBContext DB = new ShopDBContext();
        public ActionResult Index(int? page)
        {
            IEnumerable<Product> items = DB.Products.OrderByDescending(x => x.ProductId);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.ProductTypes = DB.ProductTypes.ToList();
            ViewBag.Brands=DB.Brands.ToList();
            return View();
        }    
    }
}