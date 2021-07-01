namespace ShopShoe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TenKH { get; set; }

        [StringLength(20)]
        public string SDTKH { get; set; }

        [StringLength(200)]
        public string EmailKH { get; set; }

        [Column(TypeName = "ntext")]
        public string TinNhan { get; set; }

        public DateTime? NgayGui { get; set; }
    }
}
