using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NNStore.Context
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Mã URL")]
        [Required(ErrorMessage = "Vui lòng nhập mã URL")]

        public string Slug { get; set; }
      
      
        [Display(Name = "Mô tả ngắn")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả ngắn cho sản phẩm")]
        [StringLength(500, ErrorMessage = "Mô tả ngắn phải từ 1 - 500 kí tự.", MinimumLength = 1)]
        public string ShortDes { get; set; }
        [Display(Name = "Mô tả chi tiết")]
        public string FullDescription { get; set; }
        [Display(Name = "Danh mục")]
        [Required]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required]
        public string Img { get; set; }
        [Display(Name = "Thương hiệu")]
        [Required]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Phân loại")]
        [Required]
        public Nullable<int> TypeId { get; set; }
        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public Nullable<decimal> Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]

        public Nullable<decimal> PriceSale { get; set; }
        [Display(Name = "Thời gian tạo")]
        public Nullable<int> CreatedBy { get; set; }
        [Display(Name = "Thời gian tạo")]
        public Nullable<System.DateTime> CreatedAy { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public Nullable<int> UpdatedBy { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        [Display(Name = "Quyền xóa")]
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> Status { get; set; }
    }
}