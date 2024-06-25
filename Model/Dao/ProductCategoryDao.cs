using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;
        public ProductCategoryDao() {
            db = new OnlineShopDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategory.Where(x=> x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategory.Find(id);
        }

        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategory;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(ProductCategory entity)
        {
            db.ProductCategory.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(ProductCategory entity)
        {
            try
            {
                var model = db.ProductCategory.Find(entity.ID);
                model.Name = entity.Name;
                model.MetaTitle = entity.MetaTitle;
                model.ParentID = entity.ParentID;
                model.DisplayOrder = entity.DisplayOrder;
                model.SeoTitle = entity.SeoTitle;
                model.ModifiedBy = entity.ModifiedBy;
                model.ModifiedDate = DateTime.Now;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaDescriptions = entity.MetaDescriptions;
                model.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                var product = db.ProductCategory.Find(id);
                db.ProductCategory.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public object ChangeStatus(long id)
        {
            var productcat = db.ProductCategory.Find(id);
            productcat.Status = !productcat.Status;
            db.SaveChanges();
            return productcat.Status;
        }

        public ProductCategory GetByID(long id)
        {
            return db.ProductCategory.Find(id);
        }

    }
}
