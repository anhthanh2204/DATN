using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;
using ShopShoe.ViewModels;

namespace ShopShoe.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        MyDb db = new MyDb();

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListNewProduct = db.SanPhams.OrderByDescending(x => x.ID).Take(8).ToList();
            model.ListAdidas = db.SanPhams.Where(a=>a.ID_Loai==1).OrderByDescending(x => x.ID).Take(8).ToList();
            model.ListNikes = db.SanPhams.Where(a => a.ID_Loai == 2).OrderByDescending(x => x.ID).Take(8).ToList();
            model.ListConverse = db.SanPhams.Where(a => a.ID_Loai == 3).OrderByDescending(x => x.ID).Take(8).ToList();
            model.ListPumas = db.SanPhams.Where(a => a.ID_Loai == 4).OrderByDescending(x => x.ID).Take(8).ToList();
            return View(model);
        }
        public ActionResult LoaiSanPham()
        {
            var loaixe = db.LoaiSanPhams.ToList();
            return PartialView(loaixe);
        }
        
    }
}