using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Project.Identity
{
    public class AppDBContext:IdentityDbContext<AppUser>
    {
        public AppDBContext() : base("MyConnectionString") { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}