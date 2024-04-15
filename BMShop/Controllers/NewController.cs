using Model.Dao;
using System.Web.Mvc;

namespace BMShop.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            var model = new ContentDao().ListAll();
            return View(model);
        }
    }
}