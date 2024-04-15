using Model.Dao;
using Model.EF;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BMShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Admin/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductCategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục không thành công");
                }
            }
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var productCategory = new ProductCategoryDao().GetByID(id);
            SetViewBag(productCategory.ID);
            return View(productCategory);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh mục không thành công");
                }
            }
            SetViewBag(model.ID);
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductCategoryDao().Delete(id);
            return RedirectToAction("Index", "ProductCategory");
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ProductCategoryDao();
            var categories = dao.ListAll();

            var selectListItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "Mục cha", Value = "" }
            };

            foreach (var category in categories)
            {
                selectListItems.Add(new SelectListItem { Text = category.Name, Value = category.ID.ToString() });
            }

            ViewBag.ParentID = new SelectList(selectListItems, "Value", "Text", selectedId);

        }


        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductCategoryDao().ChangeStatus(id);
            return Json(new { status = result });
        }

    }
}