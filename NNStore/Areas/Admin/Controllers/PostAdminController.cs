using NNStore.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Areas.Admin.Controllers
{
    public class PostAdminController : Controller
    {
        // GET: Admin/PostAdmin
        NNStoreEntities ojbNNStoreEntities = new NNStoreEntities();

        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstPost = new List<Post>();
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
                lstPost = ojbNNStoreEntities.Posts.Where(n => n.Title.Contains(SearchString)).ToList();
            }
            else
            {
                lstPost = ojbNNStoreEntities.Posts.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            lstPost = lstPost.OrderByDescending(n => n.Id).ToList();
            return View(lstPost.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Post objPost)
        {
            

            try
            {
                if (objPost.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objPost.ImageUpload.FileName);
                    string extention = Path.GetExtension(objPost.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                    objPost.Img = fileName;
                    objPost.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/Update"), fileName));

                    ojbNNStoreEntities.Posts.Add(objPost);
                    ojbNNStoreEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }


            }
            catch (Exception)
            {

                return View();
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objPost = ojbNNStoreEntities.Posts.Where(n => n.Id == id).FirstOrDefault();
            return View(objPost);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objPost = ojbNNStoreEntities.Posts.Where(n => n.Id == id).FirstOrDefault();
            return View(objPost);
        }
        [HttpPost]
        //public ActionResult Delete(Post post)
        //{
        //    var post = ojbNNStoreEntities.Posts.Where(n => n.Id == post.Id).FirstOrDefault();
        //    ojbNNStoreEntities.Products.Remove(post);
        //    ojbNNStoreEntities.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            var objPost = ojbNNStoreEntities.Posts.Where(n => n.Id == id).FirstOrDefault();
            Session["anhgoc"] = objPost.Img;
            return View(objPost);
        }
        [ValidateInput(false)]
        [HttpPost]

        public ActionResult Edit(int id, Post objPost)
        {
           

            try
            {
                if (objPost.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objPost.ImageUpload.FileName);
                    string extention = Path.GetExtension(objPost.ImageUpload.FileName);
                    fileName = fileName + extention;
                    objPost.Img = fileName;
                    objPost.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/Product"), fileName));

                }
                //else
                //{
                //    objProduct.Avatar = Session["anhgoc"].ToString();
                //}
                objPost.UpdateAt = DateTime.Now;
                ojbNNStoreEntities.Entry(objPost).State = EntityState.Modified;
                ojbNNStoreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}