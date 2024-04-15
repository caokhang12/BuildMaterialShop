using Model.Dao;
using Model.EF;
using System.Web.Mvc;

namespace BMShop.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Admin/About
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AboutDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new AboutDao().GetByID(id);
            return View(dao);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(About model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(About model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View();
        }

        public JsonResult ChangeStatus(long id)
        {
            var result = new AboutDao().ChangeStatus(id);
            return Json(new { status = result });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AboutDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}