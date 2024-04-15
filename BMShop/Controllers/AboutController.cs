using Model.Dao;
using System.Web.Mvc;

namespace BMShop.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var model = new AboutDao().GetAbout();
            return View(model);
        }
    }
}