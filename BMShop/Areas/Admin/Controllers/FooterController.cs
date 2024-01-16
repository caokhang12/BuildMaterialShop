using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMShop.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        // GET: Admin/Footer
        public ActionResult Index()
        {
            var dao = new FooterDao().ListAll();
            return View(dao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new FooterDao().GetByID(id);
            return View(dao);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Footer model)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Footer");
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
        public ActionResult Edit(Footer model)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDao();
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "Footer");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View();
        }

        public JsonResult ChangeStatus(int id)
        {
            var result = new FooterDao().ChangeStatus(id);
            return Json(new { status = result });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FooterDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}