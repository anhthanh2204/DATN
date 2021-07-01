using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopShoe.Models
{
    public partial class MyDb : DbContext
    {
        public MyDb()
            : base("name=MyDb")
        {
        }

        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<CT_DH> CT_DH { get; set; }
        public virtual DbSet<CT_Nhap> CT_Nhap { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<LoaiTinTuc> LoaiTinTucs { get; set; }
        public virtual DbSet<NhapHang> NhapHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT_DH>()
                .Property(e => e.GiaSanPham)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_Nhap>()
                .Property(e => e.GiaSanPham)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_Nhap>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.CT_DH)
                .WithRequired(e => e.DonHang)
                .HasForeignKey(e => e.ID_DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonHangs)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.ID_KH);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.SDTKH)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.EmailKH)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSanPham)
                .HasForeignKey(e => e.ID_Loai);

            modelBuilder.Entity<LoaiTinTuc>()
                .HasMany(e => e.TinTucs)
                .WithOptional(e => e.LoaiTinTuc)
                .HasForeignKey(e => e.ID_Loai);

            modelBuilder.Entity<NhapHang>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhapHang>()
                .HasMany(e => e.CT_Nhap)
                .WithOptional(e => e.NhapHang)
                .HasForeignKey(e => e.ID_Nhap);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.NamSX)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaSanPham)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CT_DH)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.ID_SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.NhapHang)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TinTucs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ID_AD);
        }
    }
}
