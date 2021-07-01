namespace ShopShoe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CT_DH = new HashSet<CT_DH>();
        }

        public long ID { get; set; }

        public int? ID_Loai { get; set; }

        [StringLength(200)]
        public string TenSanPham { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string NamSX { get; set; }

        [StringLength(50)]
        public string XuatSu { get; set; }

        public decimal GiaSanPham { get; set; }

        [StringLength(50)]
        public string KieuDang { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTaSanPham { get; set; }

        [StringLength(500)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DH> CT_DH { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
