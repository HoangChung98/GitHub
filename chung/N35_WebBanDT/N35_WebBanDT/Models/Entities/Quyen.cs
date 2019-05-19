namespace N35_WebBanDT.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quyen()
        {
            QuyenNguoiDungs = new HashSet<QuyenNguoiDung>();
        }

        [Key]
        [StringLength(10)]
        public string IDQuyen { get; set; }

        [StringLength(50)]
        public string TenQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuyenNguoiDung> QuyenNguoiDungs { get; set; }
    }
}
