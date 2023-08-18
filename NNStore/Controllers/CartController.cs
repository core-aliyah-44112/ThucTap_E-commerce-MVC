using NNStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Controllers
{
    public class CartController : Controller
    {
        NNStoreEntities ojbNNStore = new NNStoreEntities();
        // GET: Cart
        public ActionResult Cart()
        {
            return View((List<CartModel>)Session["cart"]);
        }
        public ActionResult AddToCart(int id, int quantity, int price)
        {
            if (quantity < 1)
            {
                return View("cart");
            }

            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                double total = price * quantity;
                cart.Add(new CartModel { Product = ojbNNStore.Products.Find(id), Price = price, Quantity = quantity });
                Session["cart"] = cart;
                Session["total"] = total;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity += quantity;
                    Session["total"] = Convert.ToInt32(Session["total"]) + quantity * price;
                }
                else
                {
                    cart.Add(new CartModel { Product = ojbNNStore.Products.Find(id), Price = price, Quantity = quantity });
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    Session["total"] = Convert.ToInt32(Session["total"]) + quantity * price;
                }
                Session["cart"] = cart;
            }

            return Json(new { Message = "Thành Công", JsonRequestBehavior.AllowGet });
        }
        private int isExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int Id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.Product.Id == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
    }
}