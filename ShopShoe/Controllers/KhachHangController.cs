using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        MyDb db = new MyDb();
        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(KhachHang model)
        {
            try
            {
                db.KhachHangs.Add(model);
                db.SaveChanges();
                return RedirectToAction("DangNhap", "KhachHang");
            }
            catch (Exception ex)
            {
                ViewBag.Loi = "Đăng ký không thành công" + ex;
                return View();
            }


        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string Email, string MatKhau)
        {
            var taikhoan = db.KhachHangs.SingleOrDefault(x => x.Email == Email && x.MatKhau == MatKhau);
            if (taikhoan != null)
            {
                Session["Ten"] = taikhoan.Ten;
                Session["KH"] = taikhoan;
                return RedirectToAction("Index", "TrangChu");
            }
            else
            {
                ViewBag.Loi = "Tài khoản hoặc mật khẩu sai";
            }
            return View();
        }
        
        public ActionResult DangXuat()
        {
            Session["Ten"] = null;
            Session["KH"] = null;
            return RedirectToAction("Index", "TrangChu");
        }
        [HttpGet]
        public ActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LienHe(LienHe model)
        {
            try {
                model.NgayGui = DateTime.Now;
                db.LienHes.Add(model);
                db.SaveChanges();
                ViewBag.ThongBao = "Thành công";
                return View();
            }
            catch
            {
                ViewBag.ThongBao = "Thất bại";
                return View();
            }
           
        }
    }
}