using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.ApiControllers
{
    public class ProductsController : ApiController
    {
        ShopDBContext DB = new ShopDBContext();
        // GET: Products
        public List<Product> Get()
        {

            List<Product> Products = DB.Products.ToList(); 
            return Products;
        }
        public Product GetProductByID(int id)
        {
            Product product = DB.Products.Find(id);

            return product;
        }
        public void Post(Product product)
        {
            DB.Products.Add(product);
            DB.SaveChanges();
        }
        public object Delete(string id)
        {
            Product db=DB.Products.Find(id);
            
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            if (db != null)
            {
                DB.Products.Remove(db);
                DB.SaveChanges();
                code = new { Success = true, msg = "", code = 1, count = DB.Categories.Count() };
            }
            return Json(code);
        }    
    }
}