using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NNStore.Models
{
    public partial class PostMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Id bài viết")]
  

        public Nullable<int> TopId { get; set; }
        [Display(Name = "Tiêu đề")]
     

        public string Title { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Chi tiết")]
      
        public string Detail { get; set; }
        [Display(Name = "Hình ảnh")]
       
        public string Img { get; set; }
        [Display(Name = "Loại bài viết")]
       
        public string PostType { get; set; }
        [Display(Name = "Nội dung")]
       
        public string MetaDesc { get; set; }
        [Display(Name = "Chi Tiết")]
      
        public string MetaKey { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public System.DateTime UpdateAt { get; set; }
        public Nullable<int> Status { get; set; }
    }
}