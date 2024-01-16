using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        OnlineShopDbContext db = null;
        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<Menu> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menu;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString) || x.Link.Contains(searchString));
            }
            return model.OrderByDescending(x => x.DisplayOrder).ToPagedList(page, pageSize);
        }

        public long Insert(Menu entity)
        {
            db.Menu.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Menu GetByID(int id)
        {
            return db.Menu.Find(id);
        }

        public bool Update(Menu entity)
        {
            try
            {
                var model = db.Menu.Find(entity.ID);
                model.Text = entity.Text;
                model.Link = entity.Link;
                model.DisplayOrder = entity.DisplayOrder;
                model.Target = entity.Target;
                model.Status = entity.Status;
                model.TypeID = entity.TypeID;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public object ChangeStatus(long id)
        {
            var content = db.Menu.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var content = db.Menu.Find(id);
                db.Menu.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menu.Where(x => x.TypeID == groupId && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
