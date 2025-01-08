using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChuyenDeASPNET.Context
{
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Display(Name = "ID Đơn hàng")]
        public int Id { get; set; }

        [Display(Name = "Tên đơn hàng")]
        public string Name { get; set; }

        [Display(Name = "ID Người dùng")]
        public int UserId { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        [Display(Name = "Ngày tạo")]
        public System.DateTime CreatedOnUtc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
