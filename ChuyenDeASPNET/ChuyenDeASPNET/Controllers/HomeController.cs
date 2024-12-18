using ChuyenDeASPNET.Context;
using ChuyenDeASPNET.Models;
using ChuyenDeASPNET.Context;
using ChuyenDeASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeASPNET.Controllers
{

    public class HomeController : Controller
    {
        ASPNETEntities1 objWebsiteASP_NETEntities1 = new ASPNETEntities1();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProduct = objWebsiteASP_NETEntities1.Products.ToList();
            objHomeModel.ListCategory = objWebsiteASP_NETEntities1.Categories.ToList();
            return View(objHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}