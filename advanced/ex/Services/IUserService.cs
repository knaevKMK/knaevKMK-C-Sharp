

namespace ex.Services
{
    using ex.Models.Service;
    using ex.Models.View;
    using ex.Models.Binding;
    using System.Collections.Generic;
    public interface IUserService
    {
        void add(UserServiceModel userServiceModel);
        List<UserViewModel> getAll(FilterDto sort);
        List<UserViewModel> getAll();
    }
}
