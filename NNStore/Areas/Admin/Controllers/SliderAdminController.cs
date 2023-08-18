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
    public class SliderAdminController : Controller
    {
        NNStoreEntities ojbNNStoreEntities = new NNStoreEntities();

       
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstSlider = ojbNNStoreEntities.Sliders.ToList();

            //Số lượng item của trang =6
            int pageSize = 6;
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            int pageNumber = (page ?? 1);
            lstSlider = lstSlider.OrderByDescending(n => n.Id).ToList();
            return View(lstSlider.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Slider slider)
        {
            try
            {
                if (slider.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(slider.ImageUpload.FileName);
                    string extention = Path.GetExtension(slider.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                    slider.Img = fileName;
                    slider.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/Sider"), fileName));
                }
                ojbNNStoreEntities.Sliders.Add(slider);
                ojbNNStoreEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return RedirectToAction("Lỗi");
            }

        }

        //[HttpGet]
        //public ActionResult Details(int Id)
        //{
        //    var objProduct = ojbNNStoreEntities.Brands.Where(n => n.Id == Id).FirstOrDefault();
        //    return View(objProduct);
        //}
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objSlider = ojbNNStoreEntities.Sliders.Where(n => n.Id == Id).FirstOrDefault();
            return View(objSlider);
        }
        [HttpPost]
        public ActionResult Delete(Slider objSlider, int Id)
        {
            objSlider.Id = Id;
            var objcategory = ojbNNStoreEntities.Sliders.Where(n => n.Id == objSlider.Id).FirstOrDefault();
            ojbNNStoreEntities.Sliders.Remove(objSlider);
            ojbNNStoreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objSlider = ojbNNStoreEntities.Sliders.Where(n => n.Id == Id).FirstOrDefault();
            Session["anhgoc"] = objSlider.Img.ToString();
            return View(objSlider);
        }
        [HttpPost]
        public ActionResult Edit(Slider slider)
        {
            try
            {
                if (slider.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(slider.ImageUpload.FileName);
                    string extension = Path.GetExtension(slider.ImageUpload.FileName);
                    fileName = fileName + extension;
                    slider.Img = fileName;
                    slider.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/Slider"), fileName));
                }
                //else
                //{
                //    brand.Avatar = Session["anhgoc"].ToString();
                //}
                slider.UpdatedAt = DateTime.Now;
                ojbNNStoreEntities.Entry(slider).State = EntityState.Modified;
                ojbNNStoreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Nhập thiếu thông tin");
            }

        }
    }
}