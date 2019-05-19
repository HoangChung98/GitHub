namespace N35_WebBanDT.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuyenNguoiDung")]
    public partial class QuyenNguoiDung
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string IDQuyen { get; set; }

        [StringLength(50)]
        public string ChuThich { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
