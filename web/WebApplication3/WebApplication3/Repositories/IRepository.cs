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
       List<T> GetAll();
        T GetById(int id);

        T Add(T entity);
        T Delete(int id);
        T Update(T entity);
    }
}
