using System.Web.Mvc;

namespace WebExperience.Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
      public JsonResult Get()
      {
          var model=new AssetController();
          return Json(model.Get());
      }
    }
}