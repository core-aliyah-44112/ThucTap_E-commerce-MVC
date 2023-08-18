using NNStore.Context;
using NNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Controllers
{
    public class HomeController : Controller
    {
            NNStoreEntities objNNStoreEntities = new NNStoreEntities();
            public ActionResult Index()
            {
                HomeModel objHomeModel = new HomeModel();
                objHomeModel.ListCategory = objNNStoreEntities.Categories.ToList();
                objHomeModel.ListProduct = objNNStoreEntities.Products.ToList();
                objHomeModel.ListSlider = objNNStoreEntities.Sliders.ToList();
                objHomeModel.ListBrand = objNNStoreEntities.Brands.ToList();
            return View(objHomeModel);
            }

            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            public ActionResult Post()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }

             public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            [HttpGet]
            public ActionResult Register()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Register(User _user)
            {
                if (ModelState.IsValid)
                {
                    var check = objNNStoreEntities.Users.FirstOrDefault(s => s.Email == _user.Email);
                    if (check == null)
                    {
                    _user.Password = GetMD5(_user.Password);
                        objNNStoreEntities.Configuration.ValidateOnSaveEnabled = false;
                        objNNStoreEntities.Users.Add(_user);
                         objNNStoreEntities.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Email already exists";
                        return View();
                    }
                }
                return View();

            }
            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(string email, string password)
            {
                if (ModelState.IsValid)
                {
                    var f_password = GetMD5(password);
                    var data = objNNStoreEntities.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                    if (data.Count() > 0)
                    {
                    //add session
                    //Session["Id"] = data.FirstOrDefault().Id;
                    Session["UserId"] = data.FirstOrDefault().Id;
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    Session["Password"] = data.FirstOrDefault().Password;
                    Session["FullName"] = data.FirstOrDefault().FullName;
                    Session["Img"] = data.FirstOrDefault().Img;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Phone"] = data.FirstOrDefault().Phone;
                    Session["Address"] = data.FirstOrDefault().Address;

                    return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
                return View();
            }
            public ActionResult Logout()
            {
                Session.Clear();//remove session
                return RedirectToAction("Login");
            }
            public static string GetMD5(string str)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fromData = Encoding.UTF8.GetBytes(str);
                byte[] targetData = md5.ComputeHash(fromData);
                string byte2String = null;

                for (int i = 0; i < targetData.Length; i++)
                {
                    byte2String += targetData[i].ToString("x2");

                }
                return byte2String;
            }

        }
    }