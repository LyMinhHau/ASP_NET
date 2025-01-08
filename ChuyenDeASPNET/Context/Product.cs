using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChuyenDeASPNET.Context
{
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Display(Name = "ID Sản phẩm")]
        public int ProductID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }

        [Display(Name = "Mô tả chi tiết")]
        public string FullDescription { get; set; }

        [Display(Name = "Hình ảnh sản phẩm")]
        public string ProductImage { get; set; }

        [Display(Name = "Giá sản phẩm")]
        public decimal Price { get; set; }

        [Display(Name = "ID Danh mục")]
        public int CategoryID { get; set; }

        [Display(Name = "ID Thương hiệu")]
        public int BrandID { get; set; }

        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreateAt { get; set; }

        [Display(Name = "Người tạo")]
        public string CreateBy { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdateAt { get; set; }

        [Display(Name = "Người cập nhật")]
        public string UpdateBy { get; set; }

        [Display(Name = "Trạng thái")]
        public Nullable<bool> Status { get; set; }

        [Display(Name = "Khuyến mãi giảm giá")]
        public Nullable<byte> ShockSale { get; set; }

        [Display(Name = "Được đề xuất")]
        public Nullable<bool> IsRecommended { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
