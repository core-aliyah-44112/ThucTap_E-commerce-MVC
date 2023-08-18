
using NNStore.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        NNStoreEntities objNNStoreEntities = new NNStoreEntities();
        // GET: Category
        [AllowAnonymous]
        public ActionResult Category()
        {
            var lstCategory = objNNStoreEntities.Categories.Where(n => n.ShowOnHomePage == true).ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int id, string currentFilter, int? page)
        {
            ViewBag.CurrentFilter = currentFilter;
            //Số item trong 1 trang = 5
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
            var lstProduct = objNNStoreEntities.Products.Where(n => n.CategoryId == id).ToList();
            Session["countPageCate"] = lstProduct.Count;
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}