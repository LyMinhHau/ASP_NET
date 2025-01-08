using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChuyenDeASPNET.Context
{
    public partial class OrderDetail
    {
        [Display(Name = "ID Chi tiết đơn hàng")]
        public int Id { get; set; }

        [Display(Name = "ID Đơn hàng")]
        public int OrderId { get; set; }

        [Display(Name = "ID Sản phẩm")]
        public int ProductId { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
