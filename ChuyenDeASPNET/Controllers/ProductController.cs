using ChuyenDeASPNET.Context;
using ChuyenDeASPNET.Models;
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
        public ActionResult Search(string searchTerm)
        {
            var searchResults = objASPEntities.Products
                .Where(p => p.ProductName.Contains(searchTerm) && p.Status == true)
                .Select(p => new ProductModel
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    ProductImage = p.ProductImage,
                    Price = p.Price
                }).ToList();

            return View("SearchResults", searchResults);
        }

    }
}
