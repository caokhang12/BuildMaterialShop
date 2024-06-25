using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        OnlineShopDbContext db = null;
        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Content entity)
        {
            db.Content.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Content GetByID(long id)
        {
            return db.Content.Find(id);
        }

        public List<Content> ListAll()
        {
            return db.Content.Where(x=>x.Status==true).ToList();
        }

        public bool Update(Content entity)
        {
            try
            {
                var model = db.Content.Find(entity.ID);
                model.Name = entity.Name;
                model.MetaTitle = entity.MetaTitle;
                model.Description = entity.Description;
                model.Image = entity.Image;
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
                model.Tags = entity.Tags;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<Content> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Content;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public object ChangeStatus(long id)
        {
            var content = db.Content.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
                {
                    var content = db.Content.Find(id);
                    db.Content.Remove(content);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
        }
    }
}
