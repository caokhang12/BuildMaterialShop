using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index( int page = 1, int pageSize = 4)
        {
            var product = new ProductDao().ListAll();
            ViewBag.Product = product;
            int totalRecord = 0;
            var model = new ProductDao().ListProduct(ref totalRecord, page, pageSize);
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.Page = page;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }

        public ActionResult Category(long id, int page=1,int pageSize=2)
        {
            var category = new ProductCategoryDao().ViewDetail(id);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(id,ref totalRecord,page,pageSize);
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.Page = page;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductDao().GetByID(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProduct = new ProductDao().ListRelatedProduct(id);
            return View(product);
        }

        public JsonResult ListName(string term)
        {
            var data = new ProductDao().ListName(term);
            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
    }
}