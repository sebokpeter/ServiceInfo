using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceInfo.DataAccess
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T entity);
        T Edit(T entity);
        void Remove(int id);

    }
}
