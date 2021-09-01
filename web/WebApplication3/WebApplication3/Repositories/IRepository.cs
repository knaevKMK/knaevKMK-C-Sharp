using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
  public   interface IRepository<T> where T : class, IEntity
    {

       Task<List<T>> GetAll();
        Task<T> GetById(int id);

        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}
