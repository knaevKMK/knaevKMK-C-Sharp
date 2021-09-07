using BattleCards_App.Data;
using BattleCards_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Repositories
{
    public class BaseRepository<T, TDbContext> : IRepository<T>
        where T : class, IEntity
        where TDbContext : AppDbContext
    {

        protected readonly AppDbContext _ctx;
        protected BaseRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public T Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public ICollection<T> GetAll()
        {
            return _ctx.Set<T>().ToList();
        }

        public T GetById(int id)
        {
          return  _ctx.Set<T>().FirstOrDefault(e=>e.Id.Equals(id));
        }

        public T Remove(int id)
        {
            T entity = GetById(id);
            if (entity!=null)
            {
                _ctx.Set<T>().Remove(entity);
                _ctx.SaveChanges();
            }
            return entity;
        }

        public T Update(int id, T entity)
        {
            T _entity = GetById(id);
            if (_entity!=null)
            {
                _ctx.Entry(_entity).CurrentValues.SetValues(entity);
                _ctx.SaveChanges();
            }
           return _entity;
        }

        public int Count() {
            return _ctx.Set<T>().Count();        }
    }
}
