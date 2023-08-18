using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NNStore.Context;

namespace NNStore.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        // GET: Admin/Order
        NNStoreEntities ojbNNStoreEntities = new NNStoreEntities();
        // GET: Admin/Order
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstOrder = new List<Order>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy tất cả các danh mucc theo từ khóa tìm kiếm
                lstOrder = ojbNNStoreEntities.Orders.Where(n => n.UserName.Contains(SearchString)).ToList();
            }
            else
            { //lấy tất cả các danh mục trong category
                lstOrder = ojbNNStoreEntities.Orders.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của trang =6
            int pageSize = 6;
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            int pageNumber = (page ?? 1);
            lstOrder = lstOrder.OrderByDescending(n => n.Id).ToList();
            return View(lstOrder.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objOrder = ojbNNStoreEntities.Orders.Where(n => n.Id == Id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objOrder = ojbNNStoreEntities.Orders.Where(n => n.Id == Id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpPost]
        public ActionResult Delete(Order objCate, int Id)
        {
            objCate.Id = Id;
            var objcategory = ojbNNStoreEntities.Orders.Where(n => n.Id == objCate.Id).FirstOrDefault();
            ojbNNStoreEntities.Orders.Remove(objcategory);
            ojbNNStoreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
