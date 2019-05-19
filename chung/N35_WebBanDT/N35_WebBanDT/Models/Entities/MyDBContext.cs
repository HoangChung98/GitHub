namespace N35_WebBanDT.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<QuyenNguoiDung> QuyenNguoiDungs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.IDHoaDon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.IDSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .Property(e => e.IDPhieuNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .Property(e => e.IDSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hang>()
                .Property(e => e.IDHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.IDHoaDon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.IDKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.IDNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.IDKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT_KH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.QuyenNguoiDungs)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.IDNCC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT_NCC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.IDNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT_NV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.IDPhieuNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.IDNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.IDNCC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.ChiTietPhieuNhaps)
                .WithRequired(e => e.PhieuNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.IDQuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.QuyenNguoiDungs)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenNguoiDung>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QuyenNguoiDung>()
                .Property(e => e.IDQuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.IDSanPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.IDNCC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.IDHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietPhieuNhaps)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
