using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedbackDao
    {
        OnlineShopDbContext db = null;
        public FeedbackDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Feedback> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedback;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(Feedback entity)
        {
            db.Feedback.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Feedback GetByID(long id)
        {
            return db.Feedback.Find(id);
        }

        public bool Update(Feedback entity)
        {
            try
            {
                var model = db.Feedback.Find(entity.ID);
                model.Name = entity.Name;
                model.Phone = entity.Phone;
                model.Email = entity.Email;
                model.Address = entity.Address;
                model.Content = entity.Content;
                model.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public object ChangeStatus(int id)
        {
            var content = db.Feedback.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var content = db.Feedback.Find(id);
                db.Feedback.Remove(content);
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
