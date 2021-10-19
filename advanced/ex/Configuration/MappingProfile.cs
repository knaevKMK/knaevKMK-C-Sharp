

namespace ex.Configuration
{
using AutoMapper;
using ex.Models;
    using ex.Models.Binding;
    using ex.Models.Service;
    using ex.Models.View;

    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            this.CreateMap<UserAddDto,UserServiceModel>();
            
            this.CreateMap<UserServiceModel, User>();


            this.CreateMap<User, UserViewModel>()
                .ForMember(model=>model.DepartmentName, cfg=> cfg.MapFrom(entity=> entity.Department.Name));
        }
    }
}
