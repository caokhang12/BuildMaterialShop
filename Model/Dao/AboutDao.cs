using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao
{
    public class AboutDao
    {
        OnlineShopDbContext db = null;
        public AboutDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<About> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<About> model = db.About;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(About entity)
        {
            db.About.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public About GetByID(long id)
        {
            return db.About.Find(id);
        }

        public About GetAbout()
        {
            return db.About.SingleOrDefault(x => x.Status == true);
        }

        public bool Update(About entity)
        {
            try
            {
                var model = db.About.Find(entity.ID);
                model.Name = entity.Name;
                model.MetaTitle = entity.MetaTitle;
                model.Description = entity.Description;
                model.Image = entity.Image;
                model.Detail = entity.Detail;
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

        public object ChangeStatus(long id)
        {
            var content = db.About.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var content = db.About.Find(id);
                db.About.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
