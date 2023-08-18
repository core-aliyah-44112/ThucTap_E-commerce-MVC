using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NNStore.Models
{
    public partial class OrderMasterData
    {
        public int Id { get; set; }
        [Display(Name = "ID Người dùng")]
        public Nullable<int> UserId { get; set; }
       
        public string Name { get; set; }
        [Display(Name = "Tên đơn hàng")]
        public string UserName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        
        public string Email { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Adress { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        
        public Nullable<int> CreatedBy { get; set; }
        [Display(Name = "Ngày đặt hàng")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        
        public Nullable<int> UpdatedBy { get; set; }
     
        public Nullable<System.DateTime> UpdatedAt { get; set; }


      
       
        
        
       
      
       
        
        
      
    }
}