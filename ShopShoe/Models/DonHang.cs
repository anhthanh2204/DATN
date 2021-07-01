namespace ShopShoe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            CT_DH = new HashSet<CT_DH>();
        }

        public int ID { get; set; }

        public int? ID_KH { get; set; }

        [StringLength(50)]
        public string Ten_KH { get; set; }

        [StringLength(200)]
        public string DiaChiKH { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        public DateTime? NgayDat { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        public decimal? TongTien { get; set; }

        public int? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DH> CT_DH { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
