using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.ApiControllers
{
    public class CategoriesController : ApiController
    {
        ShopDBContext DB=new ShopDBContext();
        public List<Category> Get()
        {
            List<Category> Categories = DB.Categories.ToList();
            return Categories;
        }
        public Category GetBrandByID(int id)
        {
            Category category = DB.Categories.Find(id);
            return category;
        }    
        public void Post(Category category)
        {
            DB.Categories.Add(category);
            DB.SaveChanges();
        }
        public void Put(List<Category> categories)
        {
            foreach (Category item in categories)
            {
                Category oldCategory = DB.Categories.Find(item.Id);
                oldCategory.Name = item.Name;
            }
            DB.SaveChanges();
        }
    }
}
