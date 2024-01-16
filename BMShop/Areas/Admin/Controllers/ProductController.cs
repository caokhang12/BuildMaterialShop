using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);

        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductDao();
            var content = dao.GetByID(id);
            SetViewBag(content.CategoryID);
            return View(content);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm không thành công");
                }
            }
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm không thành công");
                }
            }
            SetViewBag(model.CategoryID);
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index", "Product");
        }

        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new { status = result });
        }
    }
}