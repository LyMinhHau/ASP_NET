﻿using ChuyenDeASPNET.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeASPNET.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        ASPEntities objASPEntities = new ASPEntities();
        public ActionResult Index()
        {
            var lstProduct = objASPEntities.Products.ToList();
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(objASPEntities.Categories, "CategoryID", "CategoryName");
            ViewBag.BrandID = new SelectList(objASPEntities.Brands, "BrandID", "BrandName");
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
                    product.ProductImage = fileName;
                }

                objASPEntities.Products.Add(product);
                objASPEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(objASPEntities.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.BrandID = new SelectList(objASPEntities.Brands, "BrandID", "BrandName", product.BrandID);

            return View(product);
        }

        // GET: Admin/Product
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var product = objASPEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            ViewBag.CategoryID = new SelectList(objASPEntities.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.BrandID = new SelectList(objASPEntities.Brands, "BrandID", "BrandName", product.BrandID);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                if (ProductImage != null && ProductImage.ContentLength > 0)
                {
                    // Lưu hình ảnh vào thư mục Images (hoặc thư mục bạn muốn)
                    var fileName = Path.GetFileName(ProductImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/items/"), fileName);

                    // Kiểm tra nếu thư mục không tồn tại, tạo mới thư mục
                    var directory = Path.GetDirectoryName(path);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    // Lưu tệp hình ảnh
                    ProductImage.SaveAs(path);

                    // Lưu tên file hình ảnh vào thuộc tính ProductImage
                    product.ProductImage = fileName;
                }

                objASPEntities.Entry(product).State = EntityState.Modified;
                objASPEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
        // GET: Admin/Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var product = objASPEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var product = objASPEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            objASPEntities.Products.Remove(product);
            objASPEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();

            var product = objASPEntities.Products.Find(id);
            if (product == null) return HttpNotFound();

            return View(product);
        }
    }
}