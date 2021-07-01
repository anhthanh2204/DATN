using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: Admin/LoaiXe
        MyDb db = new MyDb();
        public ActionResult Index()
        {
            return View(db.LoaiSanPhams.OrderByDescending(x => x.ID).ToList());
        }
        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(LoaiSanPham model)
        {
            db.LoaiSanPhams.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "LoaiSanPham");
        }
        [HttpGet]
        public ActionResult Sua(int ID)
        {
            var chitiet = db.LoaiSanPhams.SingleOrDefault(x => x.ID == ID);
            return View(chitiet);
        }
        [HttpPost]
        public ActionResult Sua(int ID,LoaiSanPham model)
        {
            var chitiet = db.LoaiSanPhams.SingleOrDefault(x => x.ID == ID);
            chitiet.TenLoai = model.TenLoai;
            db.SaveChanges();
            return RedirectToAction("Index", "LoaiSanPham");
        }
        [HttpDelete]
        public ActionResult Xoa(int ID)
        {
            var pro = db.LoaiSanPhams.Find(ID);
            db.LoaiSanPhams.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index", "LoaiSanPham");
        }
    }
}