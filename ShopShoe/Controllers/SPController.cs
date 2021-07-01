using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Controllers
{
    public class SPController : Controller
    {
        MyDb db = new MyDb();
        // GET: SanPhams
        [HttpGet]
        public ActionResult ChiTiet(int ID)
        {
            var chitiet = db.SanPhams.SingleOrDefault(x => x.ID == ID);
            ViewBag.Cungloai = db.SanPhams.Where(x => x.ID_Loai == chitiet.ID_Loai).Take(4).ToList();
            return View(chitiet);

        }
        [HttpGet]
        public ActionResult CungLoai(int ID)
        {
            ViewBag.TenLoai = db.LoaiSanPhams.Single(x => x.ID == ID).TenLoai;
            return View(db.SanPhams.Where(x => x.ID_Loai == ID).ToList());
        }
        [HttpGet]
        public ActionResult TimKiem(String Search)
        {
            //tìm kiếm gần dúng theo tên SanPhams
            //truy xuất vào bảng SanPhams thỏa mãn điều kiện là tên SanPhams gần đúng với cái từ khóa mà người dùng nhập vào ô tìm kiếm
            var SanPhams = db.SanPhams.Where(x => x.TenSanPham.Contains(Search)).ToList();

            return View(SanPhams);
        }

    }
}