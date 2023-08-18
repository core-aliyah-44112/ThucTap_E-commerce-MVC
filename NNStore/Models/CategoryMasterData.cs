using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NNStore.Context
{
    public partial class CategoryMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required]
        public string Img { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Mã URL")]
        [Required(ErrorMessage = "Vui lòng nhập mã URL")]
        public string Slug { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> Orders { get; set; }
        [Display(Name = "Mô tả chi tiết")]
        public string MetaDesc { get; set; }
        [Display(Name = "Mô tả chi tiết")]
        public string MetaKey { get; set; }
        [Display(Name = "Thời gian tạo")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [Display(Name = "Thời gian tạo")]
        public Nullable<int> CreatedBy { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> Status { get; set; }
    }
}