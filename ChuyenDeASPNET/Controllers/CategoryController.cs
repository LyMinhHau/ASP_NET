using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChuyenDeASPNET.Context;

namespace nguyenphuthinh_2122110426.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ASPNETEntities1 objWebsiteASP_NETEntities1 = new ASPNETEntities1();
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult AllCategory()

        {
            var lstCategory = objWebsiteASP_NETEntities1.Categories.ToList();
            return View(lstCategory);

        }
        public ActionResult ProductByCategory(int Id)

        {
            var listProduct = objWebsiteASP_NETEntities1.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
    }
}