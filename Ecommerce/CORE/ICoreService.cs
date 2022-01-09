using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public interface ICoreService<T> where T:CoreEntity
    {
        //Create
        string Create(T model);

        //Create List
        string Create(List<T> models);

        //List
        List<T> GetList();

        //Get
        T GetById(Guid id);

        //Update
        string Update(T model);

        //Delete
        string Delete(T model);

        //Remove
        string RemoveForce(T model);

        //Any
        bool Any(Expression<Func<T, bool>> exp);

        //Get Default
        List<T> GetDefault(Expression<Func<T, bool>> exp);
    }
}
