using GitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {

        bool IsEmpty();
        ICollection<T> All();
        long Count();

        T Add(T entity);
        T Delete(int id);
        T GetById(int id);
    }
}
