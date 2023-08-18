using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NNStore.Context
{
    public partial class UserMasterData
    {
        [Display(Name = "Id Người dùng")]
        public int Id { get; set; }
        [Display(Name = "Tên Người dùng")]
        public string FullName { get; set; }
        [Display(Name = "Họ Người dùng")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu Người dùng")]
        public string Password { get; set; }
        [Display(Name = "Hình ảnh Người dùng")]
        public string Img { get; set; }
        [Display(Name = "Email Người dùng")]
        public string Email { get; set; }
        [Display(Name = "Giới tính Người dùng")]
        public string Gender { get; set; }
        [Display(Name = "SĐT Người dùng")]
        public Nullable<int> Phone { get; set; }
        [Display(Name = "Địa chỉ Người dùng")]
        public string Address { get; set; }
        public string Roles { get; set; }
        public int CountError { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<int> Stutus { get; set; }
    }
}