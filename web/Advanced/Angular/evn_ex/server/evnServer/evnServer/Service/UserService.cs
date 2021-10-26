


namespace evnServer.Service
{
    using AutoMapper;
    using evnServer.Model.Binding;
    using evnServer.Model.Service;
    using evnServer.Model.View;
    using evnServer.Service.Command;
    using evnServer.Service.Queries;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService: IUserService
    {
        private readonly IMediator mediator;
        private readonly IConfigurationProvider mapper;

        public UserService(IConfigurationProvider mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<int> Create(UserCreateDto userDto)
        {
           return await mediator.Send(new CreateUserCommand { 
             userServiceModel= mapper.CreateMapper().Map<UserServiceModel>(userDto)});
           }

        public async Task<List<UserViewModel>> Filter(FilterDto _filter)
        {
            return await this.mediator.Send(new FilterUsersListCommand { filter =_filter});
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            return await (this.mediator.Send(new GetUserListQuery()));
        }

        public Task<List<UserViewModel>> Sort(SortBindDto sort)
        {
                       return this.mediator.Send(new SortUserListCommand { sort=sort});
        }
    }
}
