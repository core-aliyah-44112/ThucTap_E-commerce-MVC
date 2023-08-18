using NNStore.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        NNStoreEntities objNNStoreEntities = new NNStoreEntities();
        // GET: Category
        [AllowAnonymous]
        public ActionResult Post()
        {
            var lstPost = objNNStoreEntities.Posts.Where(n => n.Id == 1).ToList();
            return View(lstPost);
        }
        //public ActionResult PostIndex(int id, string currentFilter, int? page)
        //{
        //    ViewBag.CurrentFilter = currentFilter;
        //    //Số item trong 1 trang = 5
        //    int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
        //    var lstProduct = objNNStoreEntities.Posts.Where(n => n.Id == id).ToList();
        //    Session["countPageCate"] = lstProduct.Count;
        //    return View(lstProduct.ToPagedList(pageNumber, pageSize));
        //}
    }
}