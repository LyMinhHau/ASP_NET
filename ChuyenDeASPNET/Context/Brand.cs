using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChuyenDeASPNET.Context
{
    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }

        [Display(Name = "ID Thương hiệu")]
        public int BrandID { get; set; }

        [Display(Name = "Tên thương hiệu")]
        public string BrandName { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreateAt { get; set; }

        [Display(Name = "Người tạo")]
        public string CreateBy { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdateAt { get; set; }

        [Display(Name = "Người cập nhật")]
        public string UpdateBy { get; set; }

        [Display(Name = "Thương hiệu phổ biến")]
        public Nullable<bool> IsPopular { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
