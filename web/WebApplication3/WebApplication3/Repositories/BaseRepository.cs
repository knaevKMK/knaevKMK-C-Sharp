using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public  class BaseRepository<TEntity,TContext> : IRepository<TEntity>
        where TEntity:class,IEntity
        where TContext: DbContext
    {
        private readonly DbContext _ctx;

        public BaseRepository(DbContext ctx)
        {
            _ctx = ctx;
        }

        public bool IsEmpty() {
            return _ctx.Set<TEntity>().Count<TEntity>() == 0;
        }
        public TEntity Add(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity = this.GetById(id);
            if (entity==null)
            {
                return entity;
            }

            _ctx.Set<TEntity>().Remove(entity);
            _ctx.SaveChanges();

            return entity;
        }

        public List<TEntity> GetAll(int page)
        {
           return _ctx.Set<TEntity>()
                .OrderBy(e=>e.Id)
            //    .Skip(page*20)
              //  .Take(20)
                .ToList();
        }

        public TEntity GetById(int id)
        {
            return _ctx.Set<TEntity>().Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity _entity = GetById(entity.Id);
            _ctx.Entry(_entity).CurrentValues.SetValues(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public long Count()
        {
            return _ctx.Set<TEntity>().Count();
        }
    }
}
