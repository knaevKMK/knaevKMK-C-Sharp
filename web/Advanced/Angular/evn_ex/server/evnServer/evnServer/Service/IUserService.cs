
namespace evnServer.Service
{
using System.Collections.Generic;
using System.Threading.Tasks;
    using evnServer.Model.Binding;
    using evnServer.Model.Service;
using evnServer.Model.View;
    public interface IUserService
    {
        List<UserViewModel> All();
        Task<int> Create(UserServiceModel userServiceModel);
        List<UserViewModel> filter(FilterDto sort);
    }
}
