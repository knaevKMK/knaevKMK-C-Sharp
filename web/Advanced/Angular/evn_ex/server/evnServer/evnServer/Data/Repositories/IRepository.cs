namespace evnServer.Data.Repositories
{
using System.Linq;
using System.Threading.Tasks;
  public interface IRepository<TEntity> where TEntity : class, new()
    {

        IQueryable<TEntity> GetAll();
      

        Task<TEntity> AddAsync(TEntity entity);

        int Count();
    }
}
