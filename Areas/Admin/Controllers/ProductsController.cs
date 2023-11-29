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
    [MyAuthenFilter]
    [AdminAuthorrization]
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        private ShopDBContext DB = new ShopDBContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            Product product = DB.Products.Find(id);
            List<ImgeProduct> imgeProducts = DB.Imges.Where(t => t.ProductId == id).ToList();
            ViewBag.ProductTypes = DB.ProductTypes.ToList();
            ViewBag.Brands = DB.Brands.ToList();
            ViewBag.ImageProducts = DB.Imges.Where(t => t.ProductId == id).ToList();
            return View(product);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(List<Product> Products)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (Product item in Products)
        //        {
        //            Product oldProduct = DB.Products.Find(item.ProductId);
        //            oldProduct.ProductId = item.ProductId;
        //            oldProduct.Name = item.Name;
        //            oldProduct.ProductId = item.ProductId;
        //        }
        //        DB.SaveChanges();

        //    }
        //    return RedirectToAction("Index", "Producttypes");
        //}
        [HttpPost]
        public ActionResult Edit(Product product, List<HttpPostedFileBase> uploadhinh)
        {
            Product temp = DB.Products.Find(product.ProductId);
            if (ModelState.IsValid && temp != null)
            {
                temp.BrandID = product.BrandID;
                temp.Name = product.Name;
                temp.Detail = product.Detail;
                temp.Description = product.Description;
                temp.Price = product.Price;
                temp.Quantity = product.Quantity;
                temp.Promotion = product.Promotion;
                temp.Evaluate = product.Evaluate;
                temp.TotalSold = product.TotalSold;
                temp.DateCreate = product.DateCreate;
                temp.IsHot = product.IsHot;
                temp.IsActive = product.IsActive;
                temp.ProductTypeID = product.ProductTypeID;
                temp.BrandID = temp.BrandID;
                temp.Featured = product.Featured;
                if (uploadhinh != null)
                {
                    foreach (var item in uploadhinh)
                    {

                        string _FileName = "";
                        int index = item.FileName.IndexOf('.');
                        _FileName = product.ProductId.ToString() + "." + item.FileName.Substring(index + 1);
                        string _path = Path.Combine(Server.MapPath("~/assets/img/product"), _FileName);
                        item.SaveAs(_path);

                    }
                }
                DB.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(product);
        }
        public ActionResult Create()
        {
            ViewBag.ProductTypes = DB.ProductTypes.ToList();
            ViewBag.Brands = DB.Brands.ToList();
            return View();
        }
        [HttpPost]

        public ActionResult Create(Product product, List<HttpPostedFileBase> uploadhinh)
        {
            Product temp = DB.Products.Find(product.ProductId);
            if (ModelState.IsValid && temp == null)
            {

                int n = 1;
                foreach (var item in uploadhinh)
                {
                    if (item != null && item.ContentLength > 0)
                    {
                        string _FileName = "";
                        int index = item.FileName.IndexOf('.');
                        _FileName = product.ProductId.ToString() + "-0" + n + "." + item.FileName.Substring(index + 1);
                        string _path = Path.Combine(Server.MapPath("~/assets/img/product"), _FileName);
                        item.SaveAs(_path);
                        if (n == 1)
                        {
                            product.ImgeMain = _FileName;
                            DB.Products.Add(product);
                        }
                        else
                        {
                            ImgeProduct imgeProduct = new ImgeProduct();
                            imgeProduct.ProductId = product.ProductId;
                            imgeProduct.Path = _FileName;
                            DB.Imges.Add(imgeProduct);
                            DB.SaveChanges();
                        }
                        n++;
                        DB.SaveChanges();
                    }
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