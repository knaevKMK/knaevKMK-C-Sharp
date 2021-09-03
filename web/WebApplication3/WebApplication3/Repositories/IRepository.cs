using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
  public   interface IRepository<T> where T : class, IEntity
    {
        bool IsEmpty();
       List<T> GetAll(int page);
        T GetById(int id);
        long Count();
        T Add(T entity);
        T Delete(int id);
        T Update(T entity);
    }
}
