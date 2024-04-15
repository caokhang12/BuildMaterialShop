using Model.Dao;
using Model.EF;
using System.Web.Mvc;

namespace BMShop.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FeedbackDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new FeedbackDao();
            var content = dao.GetByID(id);
            return View(content);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Feedback model)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedbackDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Feedback");
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
        public ActionResult Edit(Feedback model)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedbackDao();
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "Feedback");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhậtkhông thành công");
                }
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FeedbackDao().Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult ChangeStatus(int id)
        {
            var result = new FeedbackDao().ChangeStatus(id);
            return Json(new { status = result });
        }
    }
}