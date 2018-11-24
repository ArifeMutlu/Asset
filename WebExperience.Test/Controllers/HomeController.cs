using System;
using System.Collections.Generic;
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
            return View();
        }

        //public List<Asset> Get()
        //{
        //    var model=new AssetController();
        //    return model.Get();
        //}

    }
}