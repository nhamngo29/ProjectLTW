using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Project.Identity
{
    public class AppDBContext:IdentityDbContext<AppUser>
    {
        public AppDBContext() : base("UserConnectionString") { }
    }
}