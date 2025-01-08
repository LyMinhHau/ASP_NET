using ChuyenDeASPNET.Context;
using ChuyenDeASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ChuyenDeASPNET.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ASPEntities objASPEntities = new ASPEntities();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AllCategory()

        {
            var lstCategory = objASPEntities.Categories.ToList();

            return View(lstCategory);
        }
        public ActionResult ProductByCategory(int id, int page = 1)  // Thêm tham số page với giá trị mặc định là 1
        {
            int pageSize = 3;  // Số sản phẩm mỗi trang

            // Lấy sản phẩm của một danh mục với phân trang
            var listProduct = objASPEntities.Products
                                .Where(n => n.CategoryID == id)
                                .OrderBy(p => p.ProductID)  // Sắp xếp sản phẩm (nếu cần)
                                .Skip((page - 1) * pageSize)  // Bỏ qua các sản phẩm trước trang hiện tại
                                .Take(pageSize)  // Lấy sản phẩm cho trang hiện tại
                                .ToList();

            // Tổng số sản phẩm
            var totalItems = objASPEntities.Products.Count(n => n.CategoryID == id);
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);  // Tính tổng số trang

            // Tạo ViewModel chứa thông tin phân trang
            var model = new ProductListViewModel
            {
                Products = listProduct,
                CurrentPage = page,
                TotalPages = totalPages,
                CategoryID = id
            };

            return View(model);
        }
    }
}