using GitApp.Models;
using GitApp.Repositories;
using GitApp.Views.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Services
{
    public class UserService: IUserService
    {
        private readonly UserRepository userRepostory;

        public UserService(UserRepository userRepostory)
        {
            this.userRepostory = userRepostory;
        }

        public void Register(UserRegisterDto userDto)
        {
            if (!userDto.Password.Equals(userDto.ConfirmPassword))
            {
                throw new Exception("Password does not match");
            }
            User user1 = userRepostory.GetUserByUsername(userDto.Username);
            if (user1 != null)
            {
                throw new Exception($"User with username: {userDto.Username} alredy exst");
            }
            User user = new User {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password
            };
            userRepostory.Add(user);
        }

        string IUserService.Login(UserLoginDto userDto)
        {
          
           Models.User user = userRepostory.GetUserByUsernameAndPassword(userDto.Username, userDto.Password);
                if (user!=null)
                {
                    throw new Exception("Username or password does not match");
               }
          //TODO return ???
            return "Success Loged-In";
        }

        internal User GetCurrentUser()
        {
            //TODO get current user data
            throw new NotImplementedException();
        }
    }
}
