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
        ASPNETEntities1 objWebsiteASP_NETEntities1 = new ASPNETEntities1();
        public ActionResult ProductDetail(int Id)
        {
            var objProduct = objWebsiteASP_NETEntities1.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}