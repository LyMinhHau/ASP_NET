using ChuyenDeASPNET.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeASPNET.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ASPEntities objASPEntities = new ASPEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetail(int id)
        {
            var objProduct = objASPEntities.Products.Where(n => n.ProductID == id).FirstOrDefault();
            return View(objProduct);
        }
    }
}