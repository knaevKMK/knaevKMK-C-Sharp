
namespace EvnWithAngular.Services
{
    using EvnWithAngular.Models.Service;
    using EvnWithAngular.Models.Views;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        List<UserViewModel> All();
         Task<int> Create(UserServiceModel userServiceModel);
    }
}
