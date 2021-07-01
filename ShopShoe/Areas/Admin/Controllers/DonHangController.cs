using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        MyDb db = new MyDb();
        public ActionResult Index()
        {
            return View(db.DonHangs.OrderByDescending(x=>x.ID).ToList());
        }
        public ActionResult ChiTiet(int ID)
        {
            var chitiet = db.CT_DH.Where(x => x.ID_DonHang == ID).ToList();
            ViewBag.DonHang = db.DonHangs.SingleOrDefault(x => x.ID == ID);
            return View(chitiet);
        }
        [HttpPost]
        public ActionResult XacNhan(int id, string url)
        {
            var lst = db.DonHangs.Find(id);
            if (lst.TrangThai == 0)
            {
                lst.TrangThai = 1;
            }
            else if (lst.TrangThai == 1)
            {
                lst.TrangThai = 2;
            }
            else if (lst.TrangThai == 2)
            {
                lst.TrangThai = 3;
            }
            db.SaveChanges();
            return Redirect(url);
        }
        [HttpPost]
        public ActionResult HuyBo(int id, string url)
        {
           
            var lst = db.DonHangs.Find(id);
            if (lst.TrangThai != 4)
            {
                lst.TrangThai = 4;
            }
          
            db.SaveChanges();
            return Redirect(url);
        }
    }
}