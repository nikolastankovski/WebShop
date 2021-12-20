using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DataAccess
{
    public interface IBaseRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        int Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
