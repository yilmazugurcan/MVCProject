using CORE;
using DataAccess.Context;
using SERVICE.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //Singleton
        AppDbContext db = ProjectSingleton.Context;

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public string Create(T model)
        {
            try
            {
                model.ID = Guid.NewGuid();
                db.Set<T>().Add(model);
                db.SaveChanges();
                return "veri kaydedildi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Create(List<T> models)
        {
            try
            {
                db.Set<T>().AddRange(models);
                db.SaveChanges();
                return "veriler kaydedildi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Delete(T model)
        {
            try
            {
                T deleted = db.Set<T>().Find(model.ID);
                deleted.Status = CORE.Enum.Status.Deleted;
                Update(deleted);
                return "veri silindi!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Cast<T>().Where(exp).ToList();
        }

        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public string RemoveForce(T model)
        {

            try
            {
                T deleted = db.Set<T>().Find(model.ID);
                deleted.Status = CORE.Enum.Status.Deleted;
                db.Set<T>().Remove(deleted);
                db.SaveChanges();
                return "veri silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Update(T model)
        {
            try
            {
                if (model.Status == CORE.Enum.Status.Deleted)
                {
                    T updated = GetById(model.ID);
                    DbEntityEntry entry = db.Entry(updated);
                    entry.CurrentValues.SetValues(model);
                    db.SaveChanges();
                    return "veri silindi!";
                }
                else if (model.Status == CORE.Enum.Status.Active)
                {
                    T updated = GetById(model.ID);
                    DbEntityEntry entry = db.Entry(updated);
                    entry.CurrentValues.SetValues(model);
                    db.SaveChanges();
                    return "veri aktifleştirildi!";
                }
                else
                {
                    T updated = GetById(model.ID);
                    DbEntityEntry entry = db.Entry(updated);
                    entry.CurrentValues.SetValues(model);

                    
                    db.SaveChanges();
                    return "veri güncellendi";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
