using BattleCards_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Repositories
{
    interface IRepository<T> where T : class, IEntity
    {

        T GetById(int id);
        T Add(T entity);
        T Remove(int Id);
        T Update(int id, T entity);

        ICollection<T> GetAll();

        int Count();

    }
}
