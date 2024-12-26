using ChuyenDeASPNET.Models;
using ChuyenDeASPNET.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Users = ChuyenDeASPNET.Context.User;
namespace ChuyenDeASPNET.Controllers
{
    public class HomeController : Controller
    {
        ASPNETEntities1 objWebsiteASP_NETEntities1 = new ASPNETEntities1();

        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListCategory = objWebsiteASP_NETEntities1.Categories.ToList();
            objHomeModel.ListProduct = objWebsiteASP_NETEntities1.Products.ToList();

            return View(objHomeModel);

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users _Users)
        {
            if (ModelState.IsValid)
            {
                var check = objWebsiteASP_NETEntities1.Users.FirstOrDefault(s => s.Email == _Users.Email);
                if (check == null)
                {
                    _Users.Password = GetMD5(_Users.Password);
                    objWebsiteASP_NETEntities1.Configuration.ValidateOnSaveEnabled = false;
                    objWebsiteASP_NETEntities1.Users.Add(_Users);
                    objWebsiteASP_NETEntities1.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = objWebsiteASP_NETEntities1.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUsers"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
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