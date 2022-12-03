using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Filters;
using System.IO;

namespace Project.Areas.Admin.Controllers
{
    //[MyAuthenFilter]
    //[AdminAuthorrization]
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        private ShopDBContext DB = new ShopDBContext();
        public ActionResult Index(int? Sort = 0, int page = 1)
        {
            List<Product> products = DB.Products.ToList();
            switch (Sort)
            {
                case 1:
                    products = products.OrderBy(T => T.Price).ToList();
                    break;
                case 2:
                    products = products.OrderByDescending(T => T.Price).ToList();
                    break;
            }
            int NoOfrecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfrecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfrecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfrecordPerPage).ToList();
            return View(products); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<Product> Products)
        {
            if (ModelState.IsValid)
            {
                foreach (Product item in Products)
                {
                    Product oldProduct = DB.Products.Find(item.ProductId);
                    oldProduct.ProductId = item.ProductId;
                    oldProduct.Name = item.Name;
                    oldProduct.ProductId = item.ProductId;
                }
                DB.SaveChanges();
                
            }
            return RedirectToAction("Index", "Producttypes");
        }
        public ActionResult Create()
        {
            ViewBag.ProductTypes = DB.ProductTypes.ToList();
            ViewBag.Brands=DB.Brands.ToList();
            return View();
        }    
        [HttpPost]

        public ActionResult Create(Product product, HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    string _FileName = "";
                    int index = uploadhinh.FileName.IndexOf('.');
                    _FileName = product.ProductId.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/assets/img/product"), _FileName);
                    uploadhinh.SaveAs(_path);
                    product.ImgeMain = _FileName;
                    DB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            
            return View(product);
        }
        [HttpPost]
        public ActionResult IsActive(string id)
        {
            var item = DB.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return Json(new { success = true, isAcive = item.IsActive });
            }
            return Json(new { success = false });
        }
    }
}