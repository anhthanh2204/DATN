namespace ShopShoe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        public int ID { get; set; }

        public int? ID_Loai { get; set; }

        [StringLength(300)]
        public string TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public int? Top { get; set; }

        public int? Status { get; set; }

        public int? ID_AD { get; set; }

        public virtual LoaiTinTuc LoaiTinTuc { get; set; }

        public virtual User User { get; set; }
    }
}
