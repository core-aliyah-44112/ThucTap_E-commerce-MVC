using NNStore.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        NNStoreEntities objNNStoreEntities = new NNStoreEntities();
        // GET: Product
        public ActionResult Product(string currentFilter, string SearchString, int? page)
        {
            var listProduct = new List<Product>();
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
                //Lấy ds sản phẩm theo từ khóa tìm kiếm
                listProduct = objNNStoreEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sản phẩm trong bảng Product
                listProduct = objNNStoreEntities.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của 1 trang = 6
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            listProduct = listProduct.Where(n => n.PriceSale != null).ToList();
            return View(listProduct.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(int Id)
        {
            var objProduct = objNNStoreEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            var listProduct = new List<Product>();
            listProduct = objNNStoreEntities.Products.ToList();

            return View(objProduct);
        }
    }
}