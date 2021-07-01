using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        MyDb db = new MyDb();
        public ActionResult Index()
        {
            ViewBag.Quantity = db.SanPhams.Sum(x => x.SoLuong);
            ViewBag.Customer = db.KhachHangs.Count();
            ViewBag.LienHe = db.LienHes.Count();
            ViewBag.DonHang = db.DonHangs.Where(x => x.TrangThai == 0).Count();
            return View();
        }
    }
}