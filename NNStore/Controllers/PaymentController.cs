using NNStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Controllers
{
    public class PaymentController : Controller
    {
        NNStoreEntities dbWeb = new NNStoreEntities();
        // GET: Payment
        public ActionResult Payment()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //Lấy infor từ giỏ hàng từ biến Sesstion
                var lstCart = (List<CartModel>)Session["cart"];
                //Gán dữ liệu cho order
                Order objOrder = new Order();
                objOrder.UserName = "Đơn hàng " + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["UserId"].ToString());
                objOrder.CreatedAt = DateTime.Now;
                objOrder.Status = 1;
                dbWeb.Orders.Add(objOrder);
                //Lưu infor dữu liệu vào bảng Order 
                dbWeb.SaveChanges();
                //Lấy OrderId vừa mới tạo để lưu vào bảng orderdetail.
                int intOrderId = objOrder.Id;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Qty = item.Quantity;
                    obj.Id = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                dbWeb.OrderDetails.AddRange(lstOrderDetail);
                dbWeb.SaveChanges();
            }
            return View();
        }
    }
}