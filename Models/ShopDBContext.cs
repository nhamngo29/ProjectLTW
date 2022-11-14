using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project.Models;
namespace Project.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext() : base("MyConnectionString") { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ImgeProduct> Imges { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<PropertieProduct> Properties { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        
    }
}