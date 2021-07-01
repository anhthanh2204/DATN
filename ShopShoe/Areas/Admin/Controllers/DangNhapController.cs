using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Admin/DangNhap
        MyDb db = new MyDb();
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email, string MatKhau)
        {
            var admin = db.Users.Where(x => x.Email.Equals(Email) && x.MatKhau.Equals(MatKhau)).FirstOrDefault();
            if (admin != null)
            {
                Session["Ten"] = admin.Ten;
                Session["User"] = admin;
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                ViewBag.ThongBao = "<p class='text-danger'>Tai khoan hoac mat khau sai!</p>";
                return View();
            }
        }
        public ActionResult DangXuat()
        {
            Session["Ten"] = null;
            Session["User"] = null;
            return RedirectToAction("Index", "DangNhap");
        }
    }
}