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
    }
}