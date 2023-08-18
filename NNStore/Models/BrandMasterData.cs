using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NNStore.Context
{
    public partial class BrandMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên thương hiệu")]
        [Required(ErrorMessage = "Vui lòng nhập tên thương hiệu")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Img { get; set; }
        [Display(Name = "Mã Url")]
        [Required(ErrorMessage = "Vui lòng nhập mã url")]
        public string Slug { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Thời gian tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public Nullable<System.DateTime> UpdateUtc { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}