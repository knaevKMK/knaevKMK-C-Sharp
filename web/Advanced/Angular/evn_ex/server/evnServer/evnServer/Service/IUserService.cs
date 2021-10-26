using evnServer.Model.Binding;
using evnServer.Model.Service;
using evnServer.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evnServer.Service
{
    public interface IUserService
    {
       Task <List<UserViewModel>> GetAll();
        Task<int> Create(UserCreateDto userServiceModel);
        Task<List<UserViewModel>> Filter(FilterDto filter);
        Task<List<UserViewModel>> Sort(SortBindDto sort);
    }
}
