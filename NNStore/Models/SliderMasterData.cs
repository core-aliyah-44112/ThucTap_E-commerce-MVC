using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NNStore.Context
{
    public partial class SliderMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên slide")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Img { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> Status { get; set; }
    }
}