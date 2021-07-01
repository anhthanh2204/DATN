using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;
using ShopShoe.ViewModels;


namespace ShopShoe.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        MyDb db = new MyDb();
        public ActionResult Cart()
        {
            if (Session["Cart"] != null)
            {
                List<CartItems> lstcart = GetCart();
                ViewBag.TongSL = TotalQty();
                ViewBag.TongTien = TotalPrice();
                return View(lstcart);
            }
            return View();

        }
        public List<CartItems> GetCart()
        {
            List<CartItems> lstCart = Session["Cart"] as List<CartItems>;

            if (lstCart == null)
            {
                //Create list cart
                lstCart = new List<CartItems>();

                Session["Cart"] = lstCart;
            }
            return lstCart;
        }
        public ActionResult AddCart(int id, string url)
        {
            //Products pro = db.Products.SingleOrDefault(x => x.ID == id);
            //Get list cart
            List<CartItems> lstcart = GetCart();

            CartItems cart = lstcart.Find(x => x.ID == id);
            if (cart == null)
            {
                cart = new CartItems(id);

                lstcart.Add(cart);
                return Redirect(url);
            }
            else
            {
                if (cart.SoLuong < 2)
                {
                    cart.SoLuong++;
                    return Redirect(url);
                }
                else { return Redirect(url); }

            }
        }
        public ActionResult UpdateCart(int id, FormCollection frm)
        {

            List<CartItems> lstcart = GetCart();
            //Kiem tra ID sach trong Session
            CartItems cart = lstcart.SingleOrDefault(x => x.ID == id);
            if (cart != null)
            {
                cart.SoLuong = int.Parse(frm["SoLuong"].ToString());

            }
            return RedirectToAction("Cart", "Cart");
        }
        public ActionResult DeleteCart(int id)
        {
            List<CartItems> lstcart = GetCart();
            CartItems cart = lstcart.SingleOrDefault(x => x.ID == id);
            if (cart != null)
            {
                lstcart.RemoveAll(x => x.ID == id);

            }
            if (lstcart.Count == 0)
            {
                Session["Cart"] = null;
            }
            return RedirectToAction("Cart", "Cart");
        }
        private int TotalQty()
        {
            int qty = 0;
            List<CartItems> lstCart = Session["Cart"] as List<CartItems>;
            if (lstCart != null)
            {
                qty = lstCart.Sum(x => x.SoLuong);
            }
            return qty;
        }
        private double TotalPrice()
        {
            double total = 0;
            List<CartItems> lstCart = Session["Cart"] as List<CartItems>;
            if (lstCart != null)
            {
                total = lstCart.Sum(x => x.ThanhTien);
            }
            return total;
        }
        public ActionResult SoCart()
        {
            ViewBag.TongSL = TotalQty();
            ViewBag.TongTien = TotalPrice();
            return PartialView();
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            if (Session["KH"] == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            KhachHang kh = (KhachHang)Session["KH"];
            ViewBag.KH = kh;
            List<CartItems> lstcart = GetCart();
            ViewBag.TongTien = TotalPrice();
            return View(lstcart);
        }
        [HttpPost]
        public ActionResult ThanhToan(DonHang model)
        {
            KhachHang KH = (KhachHang)Session["KH"];
            List<CartItems> lstcart = GetCart();

            model.ID_KH = KH.ID;
            model.NgayDat = DateTime.Now;
            model.TrangThai = 0;
            model.TongTien = (decimal)TotalPrice();

            db.DonHangs.Add(model);
            db.SaveChanges();
            foreach (var item in lstcart)
            {
                CT_DH ct = new CT_DH();
                ct.ID_DonHang = model.ID;
                ct.ID_SanPham = item.ID;
                ct.SoLuong = item.SoLuong;
                ct.GiaSanPham = (decimal)item.GiaXe;
                db.CT_DH.Add(ct);
            }
            db.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("Index", "TrangChu");
        }

    }
}