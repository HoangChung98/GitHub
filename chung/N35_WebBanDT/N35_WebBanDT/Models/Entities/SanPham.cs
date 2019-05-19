namespace N35_WebBanDT.Models.Entities
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
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        [StringLength(10)]
        public string IDSanPham { get; set; }

        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(200)]
        public string UrlAnh { get; set; }

        [StringLength(20)]
        public string DVT { get; set; }

        public double? DonGiaN { get; set; }

        public double? DonGiaB { get; set; }

        [StringLength(50)]
        public string ManHinh { get; set; }

        [StringLength(50)]
        public string HeDieuHanh { get; set; }

        [StringLength(50)]
        public string CameraSau { get; set; }

        [StringLength(50)]
        public string CameraTruoc { get; set; }

        [StringLength(50)]
        public string BoNhoTrong { get; set; }

        [StringLength(50)]
        public string Ram { get; set; }

        [StringLength(50)]
        public string CPU { get; set; }

        [StringLength(50)]
        public string DungLuongPin { get; set; }

        [StringLength(50)]
        public string TheSim { get; set; }

        [StringLength(50)]
        public string TGBaoHanh { get; set; }

        [StringLength(10)]
        public string IDNCC { get; set; }

        [StringLength(10)]
        public string IDHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
