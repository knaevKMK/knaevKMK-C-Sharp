namespace EvnWithAngular.Infrastructure
{
    using AutoMapper;
    using EvnWithAngular.Models.Binding;
    using EvnWithAngular.Models.Entites;
    using EvnWithAngular.Models.Service;
    using EvnWithAngular.Models.Views;
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            this.CreateMap<UserCreateDto, UserServiceModel>();
            this.CreateMap<UserServiceModel, User>();

            this.CreateMap<User, UserViewModel>()
                .ForMember(model => model.DepartmentName, cfg => cfg.MapFrom(user => user.Department.Name));

            
        }
    }
}
