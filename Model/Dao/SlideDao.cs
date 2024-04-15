using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao
{
    public class SlideDao
    {
        OnlineShopDbContext db = null;
        public SlideDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Slide> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slide;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.DisplayOrder).ToPagedList(page, pageSize);
        }

        public long Insert(Slide entity)
        {
            db.Slide.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Slide GetByID(int id)
        {
            return db.Slide.Find(id);
        }

        public bool Update(Slide entity)
        {
            try
            {
                var model = db.Slide.Find(entity.ID);
                model.Image = entity.Image;
                model.Link = entity.Link;
                model.DisplayOrder = entity.DisplayOrder;
                model.Description = entity.Description;
                model.ModifiedBy = entity.ModifiedBy;
                model.ModifiedDate = DateTime.Now;
                model.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public object ChangeStatus(int id)
        {
            var content = db.Slide.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var content = db.Slide.Find(id);
                db.Slide.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Slide> ListAll()
        {
            return db.Slide.Where(x=>x.Status==true).OrderByDescending(y=>y.DisplayOrder).ToList();
        }
    }
}
