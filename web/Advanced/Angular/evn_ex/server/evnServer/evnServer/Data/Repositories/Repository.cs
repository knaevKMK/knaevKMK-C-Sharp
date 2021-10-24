

namespace evnServer.Data.Repositories
{
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {

        protected readonly ApplicationDbContext data;

        protected Repository(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
            EntityEntry<TEntity> entityEntry = await   data.Set<TEntity>().AddAsync(entity).AsTask();
          await  data.SaveChangesAsync();
            return entityEntry.Entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public int Count()
        {
            return data.Set<TEntity>().Count<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return data.Set<TEntity>();
        }

       
    }
}
