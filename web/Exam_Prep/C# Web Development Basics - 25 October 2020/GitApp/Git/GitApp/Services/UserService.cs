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
            

            if (userRepostory.GetUserByUsername(userDto.Username)!=null)
            {
                throw new Exception($"User with username: {userDto.Username} alredy exst");
            }
            User user = new User {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,

            
            };
            userRepostory.Add(user);
        }

        string IUserService.Login(UserLoginDto userDto)
        {
            try
            {
                Models.User user = userRepostory.GetUserByUsername(userDto.Username, userDto.Password);
                if (user==null)
                {
                    throw new Exception("Username or password does not match");
                }
            }
            catch (Exception)
            {
                throw new Exception("Username or password does not match");
            }
            return "Get Token";
        }
    }
}
