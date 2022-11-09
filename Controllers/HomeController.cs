﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ShopDBContext DB=new ShopDBContext();
        public ActionResult Index()
        {
            List<Slide> Slides=DB.Slides.ToList();
            ViewBag.Slides=Slides;
            List<ImgeProduct> imges=DB.Imges.ToList();
            List<Product> Products=DB.Products.ToList();
            List<Detail> Details=DB.Details.ToList();
            ViewBag.Detail=Details;
            return View(Products);
        }
    }
}