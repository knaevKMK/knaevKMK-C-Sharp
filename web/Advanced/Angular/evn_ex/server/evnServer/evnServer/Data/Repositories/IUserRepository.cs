
namespace evnServer.Data.Repositories
{
using evnServer.Model.Binding;
using evnServer.Model.Entity;
using System.Linq;
  public  interface IUserRepository:IRepository<User>
    {
        IQueryable<User> Sort(FilterDto sort);
    }
}
