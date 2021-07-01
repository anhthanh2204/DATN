using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Areas.Admin.Controllers
{
    public class ADKhachHangController : Controller
    {
        // GET: Admin/ADKhachHang
        MyDb db = new MyDb();
        public ActionResult Index()
        {
            return View(db.KhachHangs.OrderByDescending(x => x.ID).ToList());
        }
        public ActionResult ChiTiet(int ID)
        {
            var chitiet = db.KhachHangs.SingleOrDefault(x => x.ID == ID);
            return View(chitiet);
        }
        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(User model)
        {
            db.Users.Add(model);
            db.SaveChanges();
            return View();
        }
    }
}