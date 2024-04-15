using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Product GetByID(long id)
        {
            return db.Product.Find(id);
        }

        public List<Product> ListAll()
        {
            return db.Product.ToList();
        }

        public List<string> ListName(string keyword)
        {
            return db.Product.Where(x=>x.Name.Contains(keyword)).Select(x=>x.Name).ToList();
        }

        public bool Update(Product entity)
        {
            try
            {
                var model = db.Product.Find(entity.ID);
                model.Name = entity.Name;
                model.Code = entity.Code;
                model.MetaTitle = entity.MetaTitle;
                model.Description = entity.Description;
                model.Image = entity.Image;
                model.Name = entity.Name;
                model.MoreImages = entity.MoreImages;
                model.Price = entity.Price;
                model.PromotionPrize = entity.PromotionPrize;
                model.Quantity = entity.Quantity;
                model.CategoryID = entity.CategoryID;
                model.Detail = entity.Detail;
                model.Warranty = entity.Warranty;
                model.ModifiedBy = entity.ModifiedBy;
                model.ModifiedDate = DateTime.Now;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaDescriptions = entity.MetaDescriptions;
                model.Status = entity.Status;
                model.TopHot = entity.TopHot;
                model.ViewCount = entity.ViewCount;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                var product = db.Product.Find(id);
                db.Product.Remove(product);
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
            var product = db.Product.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }


        public List<Product> ListByCategoryId(long categoryID,ref int totalRecord,int page= 1, int pageSize = 2)
        {
            totalRecord = db.Product.Where(x => x.CategoryID == categoryID).Count();
            var model =  db.Product.Where(x => x.CategoryID == categoryID).OrderByDescending(x=>x.CreatedDate).Skip((page -1)*pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Product> ListProduct(ref int totalRecord, int page = 1, int pageSize = 4)
        {
            totalRecord = db.Product.Count();
            var model = db.Product.Where(x=>x.Status==true).OrderByDescending(x=>x.ID).Skip((page -1)*pageSize).Take( pageSize).ToList();
            return model;
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Product.OrderByDescending(x=>x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Product.Where(x=>x.TopHot!=null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();

        }
        public List<Product> ListRelatedProduct(long productID)
        {
            var product = db.Product.Find(productID);
            return db.Product.Where(x => x.ID != productID && x.CategoryID == product.CategoryID).ToList();

        }
    }
}
