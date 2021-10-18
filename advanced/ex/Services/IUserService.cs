using ex.Models.Service;
using ex.Models.View;
using ex.Models.Binding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ex.Services
{
   public interface IUserService
    {
        void add(UserServiceModel userServiceModel);
         object getAll(FilterDto sort);
        List<UserViewModel> getAll();
    }
}
