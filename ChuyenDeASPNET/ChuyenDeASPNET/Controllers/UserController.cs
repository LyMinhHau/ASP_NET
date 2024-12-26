using ChuyenDeASPNET.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeASPNET.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "hau" && password == "123456")
            {
                
                Session["UserID"] = "1"; 
                Session["UserName"] = username; 
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("thatbai");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User _user)
        {
            //Ktra va luu db
            return View("Index");
        }
    }
}