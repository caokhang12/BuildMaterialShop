using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao() {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.Name = entity.Name;
                if(!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.GroupID = entity.GroupID;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public  IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize) 
        {
            IQueryable<User> model = db.User;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x=>x.CreatedDate).ToPagedList(page,pageSize);
        }

        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var user = db.User.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public int Login(string userName, string password, bool isLoginAdmin =false)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName );
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true )
                {
                    if( result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                            {
                                return 1;
                            }
                            else
                            { return -2; }
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                            {
                                return 1;
                            }
                            else
                            { return -2; }
                        }
                    }
                }
                
            }

        }

        public List<User> ListAll()
        {
            return db.User.Where(x => x.Status == true).ToList();
        }
        public bool CheckUserName(string userName)
        {
            return db.User.Count(x=>x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.User.Count(x => x.Email == email) > 0;
        }
    }
}
