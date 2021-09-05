using GitApp.Views.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Services
{
    public interface IUserService
    {

        string Login(UserLoginDto userDto);
        void Register(UserRegisterDto userDto);
    }
}
