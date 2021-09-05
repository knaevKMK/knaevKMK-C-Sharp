using GitApp.Data;
using GitApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Repositories
{
    public abstract class BaseRepository<T,TContext> : IRepository<T>
        where T : class, IEntity
        where TContext: GitDbContext
    {
        protected readonly GitDbContext ctx;

        public BaseRepository(GitDbContext ctx)
        {
            this.ctx = ctx;
        }

        public T Add(T entity)
        {
            ctx.Set<T>().Add(entity);
            return entity;
        }

        public virtual ICollection<T> All()
        {
            return ctx.Set<T>()
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
               
                    throw new Exception(entity.GetType().Name +" does not exist");
               
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
