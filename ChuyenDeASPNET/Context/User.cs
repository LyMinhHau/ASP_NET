using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChuyenDeASPNET.Context
{
    public partial class User
    {
        [Display(Name = "ID Người dùng")]
        public int idUser { get; set; }

        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
}
