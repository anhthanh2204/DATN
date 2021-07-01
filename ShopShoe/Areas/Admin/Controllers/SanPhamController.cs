using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/Xe

        MyDb db = new MyDb();
        public ActionResult Index()
        {
            return View(db.SanPhams.OrderByDescending(x => x.ID).ToList());
        }
        [HttpGet]
        public ActionResult Them()
        {
            var loaixe = db.LoaiSanPhams.ToList();
            SelectList loaixe_l = new SelectList(loaixe, "ID", "TenLoai");
            ViewBag.LoaiXe = loaixe_l;
            return View();
        }
        [HttpPost]
        public ActionResult Them(SanPham model, HttpPostedFileBase Anh)
        {
            if (Anh != null)
            {
                var path = Server.MapPath("~/anh/xe/" + Anh.FileName);
                Anh.SaveAs(path);
                model.Anh = Anh.FileName;
                db.SanPhams.Add(model);
                db.SaveChanges();
            }
            else
            {
                db.SanPhams.Add(model);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "SanPham");
        }
        [HttpGet]
        public ActionResult Sua(int ID)
        {


            var chitiet = db.SanPhams.SingleOrDefault(x => x.ID == ID);
            var loaixe = db.LoaiSanPhams.ToList();
            SelectList loaixe_l = new SelectList(loaixe, "ID", "TenLoai");
            ViewBag.LoaiXe = loaixe_l;
            return View(chitiet);
        }
        [HttpPost]
        public ActionResult Sua(int ID, SanPham model, HttpPostedFileBase Anh)
        {
            if (Anh != null)
            {
                var chitiet = db.SanPhams.SingleOrDefault(x => x.ID == ID);

                var path = Server.MapPath("~/anh/xe/" + Anh.FileName);
                Anh.SaveAs(path);
                chitiet.Anh = Anh.FileName;
                chitiet.TenSanPham = model.TenSanPham;
                chitiet.SoLuong = model.SoLuong;
                chitiet.NamSX = model.NamSX;
                chitiet.XuatSu = model.XuatSu;
                chitiet.GiaSanPham = model.GiaSanPham;
                chitiet.KieuDang = model.KieuDang;
                chitiet.MoTaSanPham = model.MoTaSanPham;
                chitiet.ID_Loai = model.ID_Loai;
                db.SaveChanges();
            }
            else
            {
                var chitiet = db.SanPhams.SingleOrDefault(x => x.ID == ID);
                chitiet.TenSanPham = model.TenSanPham;
                chitiet.SoLuong = model.SoLuong;
                chitiet.NamSX = model.NamSX;
                chitiet.XuatSu = model.XuatSu;
                chitiet.GiaSanPham = model.GiaSanPham;
                chitiet.KieuDang = model.KieuDang;
                chitiet.MoTaSanPham = model.MoTaSanPham;
                chitiet.ID_Loai = model.ID_Loai;
                db.SaveChanges();

            }
            return RedirectToAction("Index", "SanPham");

        }
        [HttpDelete]
        public ActionResult Xoa(int ID)
        {
            var pro = db.SanPhams.Find(ID);
            db.SanPhams.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index", "SanPham");
        }
    }
}