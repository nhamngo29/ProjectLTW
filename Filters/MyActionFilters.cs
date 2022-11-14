using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Filters
{
    public class MyActionFilters : FilterAttribute, IActionFilter
    {
        ShopDBContext DB=new ShopDBContext();
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}