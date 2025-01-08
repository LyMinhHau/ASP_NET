using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChuyenDeASPNET.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
    }
}