using NNStore.Context;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace NNStore.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<User> User { get; set; }
        public List<Order> ListOrder { get; set; }
        public List<OrderDetail> ListOrderDetail { get; set; }
        public List<Config> ListConfig { get; set; }
        public List<Link> ListLink { get; set; }
        public List<Menu> ListMenu { get; set; }
        public List<Post> ListPost { get; set; }
        public List<Slider> ListSlider { get; set; }
        public List<Topic> ListTopic { get; set; }
        public List<Brand> ListBrand { get; set; }
       
        public int Id { get; set; }
        public Nullable<decimal> Price { get; set; }

    }
}