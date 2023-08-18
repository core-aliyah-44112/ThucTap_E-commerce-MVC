using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NNStore.Context;

namespace NNStore.Areas.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {
        // GET: Admin/CategoryAdmin
        NNStoreEntities ojbNNStoreEntities = new NNStoreEntities();

        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstCategory = new List<Category>();
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
                lstCategory = ojbNNStoreEntities.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            { //lấy tất cả các danh mục trong category
                lstCategory = ojbNNStoreEntities.Categories.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của trang =6
            int pageSize = 6;
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            int pageNumber = (page ?? 1);
            lstCategory = lstCategory.OrderByDescending(n => n.Id).ToList();
            return View(lstCategory.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (category.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(category.ImageUpload.FileName);
                    string extention = Path.GetExtension(category.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                    category.Img = fileName;
                    category.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/Category"), fileName));
                }
                ojbNNStoreEntities.Categories.Add(category);
                ojbNNStoreEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return RedirectToAction("Lỗi");
            }
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objProduct = ojbNNStoreEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = ojbNNStoreEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Category  objCate, int Id)
        {
            objCate.Id = Id;
            var objcategory = ojbNNStoreEntities.Categories.Where(n => n.Id == objCate.Id).FirstOrDefault();
            ojbNNStoreEntities.Categories.Remove(objcategory);
            ojbNNStoreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objProduct = ojbNNStoreEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (category.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(category.ImageUpload.FileName);
                    string extension = Path.GetExtension(category.ImageUpload.FileName);
                    fileName = fileName + extension;
                    category.Img = fileName;
                    category.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                category.UpdatedAt = DateTime.Now;
                ojbNNStoreEntities.Entry(category).State = EntityState.Modified;
                ojbNNStoreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }
    }
}