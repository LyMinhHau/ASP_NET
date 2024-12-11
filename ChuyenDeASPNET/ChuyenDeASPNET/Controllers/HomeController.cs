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
        ASPNETEntities objASPNETEntities = new ASPNETEntities();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();

            objHomeModel.ListCategory = objASPNETEntities.Categories.ToList();
            objHomeModel.ListProduct = objASPNETEntities.Products.ToList();
            var lstProduct = objASPNETEntities.Products.ToList();
            return View(objHomeModel);
        }


    }
}