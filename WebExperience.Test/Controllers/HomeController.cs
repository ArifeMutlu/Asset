using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Asset(Guid id)
        {
            var model = new AssetController();
            return View(model.Get(id));
        }
        public ActionResult AssetDetail(Guid id)
        {
            var model = new AssetController();
            return View(model.Get(id));
        }
        public ActionResult AssetCreate()
        {
            return View();
        }
        public ActionResult DeleteAsset(Guid id)
        {
            var model=new AssetController();
            model.DeleteAsset(id);
            return RedirectToAction("Index","Home");
        }
    }
}