using NNStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNStore.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        NNStoreEntities objNNStoreEntities = new NNStoreEntities();
        // GET: Category
        [AllowAnonymous]
        public ActionResult Index()
        {
            var lstCategory = objNNStoreEntities.Categories.Where(n => n.ShowOnHomePage == true).ToList();
            return View(lstCategory);
        }
        
    }
}