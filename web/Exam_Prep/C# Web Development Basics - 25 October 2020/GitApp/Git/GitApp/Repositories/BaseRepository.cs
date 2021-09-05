using GitApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Repositories
{
    public class BaseRepository<T,TContext> : IRepository<T>
        where T : class, IEntity
        where TContext: DbContext
    {
        private readonly DbContext ctx;

        public BaseRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public T Add(T entity)
        {
            ctx.Set<T>().Add(entity);
            return entity;
        }

        public ICollection<T> All()
        {
            return ctx.Set<T>()
                //orderIf need
                .ToList();
        }

        public long Count()
        {
            return ctx.Set<T>().Count();
        }

        public T Delete(int id)
        {
            T entity = GetById(id);
            if (entity==null)
            {
                return null;
            }
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();

            return entity;
        }

        public T GetById(int id)
        {
            return ctx.Set<T>().Find(id);
        }

        public bool IsEmpty()
        {
            return Count() == 0;
        }
    }
}
