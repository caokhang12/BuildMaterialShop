using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FooterDao
    {
        OnlineShopDbContext db = null;
        public FooterDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Footer> ListAll()
        {
            return db.Footer.ToList();
        }

        public long Insert(Footer entity)
        {
            db.Footer.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Footer GetByID(long id)
        {
            return db.Footer.Find(id);
        }

        public bool Update(Footer entity)
        {
            try
            {
                var model = db.Footer.Find(entity.ID);
                model.Content = entity.Content;
                model.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public object ChangeStatus(int id)
        {
            var content = db.Footer.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var content = db.Footer.Find(id);
                db.Footer.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Footer GetFooter()
        {
            return db.Footer.SingleOrDefault(x =>x.Status==true);
        }
    }
}
