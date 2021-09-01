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
        private readonly TContext _ctx;

        public BaseRepository(TContext ctx)
        {
            _ctx = ctx;
        }

        public Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
