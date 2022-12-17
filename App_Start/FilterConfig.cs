using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Filters;
namespace Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new MyExeptionFilter());
            filters.Add(new HandleErrorAttribute() { ExceptionType=typeof(Exception),View="Error"});
        }
    }
}