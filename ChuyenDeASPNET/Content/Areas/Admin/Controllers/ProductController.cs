using ChuyenDeASPNET.Context;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeASPNET.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ASPNETEntities1 objASPNETEntities = new ASPNETEntities1();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = objASPNETEntities.Products.ToList();
            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(objASPNETEntities.Categories, "CategoryID", "CategoryName");
            ViewBag.BrandID = new SelectList(objASPNETEntities.Brands, "BrandID", "BrandName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                if (ProductImage != null && ProductImage.ContentLength > 0)
                {
                    // Lưu hình ảnh vào thư mục Images (hoặc thư mục bạn muốn)
                    var fileName = Path.GetFileName(ProductImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/items/"), fileName);
                    ProductImage.SaveAs(path);

                    // Lưu tên file hình ảnh vào thuộc tính ProductImage
                    
                }

                objASPNETEntities.Products.Add(product);
                objASPNETEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(objASPNETEntities.Categories, "CategoryID", "CategoryName", product.CategoryId);
            ViewBag.BrandID = new SelectList(objASPNETEntities.Brands, "BrandID", "BrandName", product.BrandId);

            return View(product);
        }

        // GET: Admin/Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var product = objASPNETEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            ViewBag.CategoryID = new SelectList(objASPNETEntities.Categories, "CategoryID", "CategoryName", product.CategoryId);
            ViewBag.BrandID = new SelectList(objASPNETEntities.Brands, "BrandID", "BrandName", product.BrandId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                objASPNETEntities.Entry(product).State = System.Data.Entity.EntityState.Modified;
                objASPNETEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(objASPNETEntities.Categories, "CategoryID", "CategoryName", product.CategoryId);
            ViewBag.BrandID = new SelectList(objASPNETEntities.Brands, "BrandID", "BrandName", product.BrandId);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var product = objASPNETEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var product = objASPNETEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            objASPNETEntities.Products.Remove(product);
            objASPNETEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();

            var product = objASPNETEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            return View(product);
        }
    }
}
