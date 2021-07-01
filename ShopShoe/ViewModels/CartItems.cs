using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopShoe.Models;

namespace ShopShoe.ViewModels
{
    public class CartItems
    {
        MyDb db = new MyDb();
        public long ID { get; set; }
        public string TenXe { get; set; }
        public string Anh { get; set; }
        public double GiaXe { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get { return SoLuong * GiaXe; }
        }
        public CartItems(int id)
        {
            ID = id;
            SanPham xe = db.SanPhams.Single(x => x.ID == id);
            TenXe = xe.TenSanPham;
            Anh = xe.Anh;
            GiaXe = double.Parse(xe.GiaSanPham.ToString());
            SoLuong = 1;

        }
    }
}