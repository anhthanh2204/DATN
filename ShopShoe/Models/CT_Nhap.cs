namespace ShopShoe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_Nhap
    {
        public int ID { get; set; }

        public int? ID_Nhap { get; set; }

        [StringLength(200)]
        public string TenSanPham { get; set; }

        public decimal? GiaSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }

        public virtual NhapHang NhapHang { get; set; }
    }
}
