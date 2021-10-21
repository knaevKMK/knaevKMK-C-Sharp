
namespace evnServer.Config
{
using AutoMapper;
using evnServer.Model.Binding;
using evnServer.Model.Entity;
using evnServer.Model.Service;
using evnServer.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class MapperProfile:Profile
    {

        public MapperProfile()
        {
            this.CreateMap<UserCreateDto, UserServiceModel>();
            this.CreateMap<UserServiceModel, User>();

            this.CreateMap<User, UserViewModel>()
                .ForMember(model => model.DepartmentName, cfg => cfg.MapFrom(user => user.Department.Name));


            this.CreateMap<Department, DepartmentViewModel>();

        }
    }
}
