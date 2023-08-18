using NNStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNStore.Context

{
    public partial class CartModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        
        public Nullable<decimal> PriceSale { get; set; }
    }
}