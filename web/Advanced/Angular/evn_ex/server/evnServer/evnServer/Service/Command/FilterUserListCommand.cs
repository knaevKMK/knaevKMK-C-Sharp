namespace evnServer.Service.Command
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using evnServer.Data.Repositories;
    using evnServer.Model.Binding;
    using evnServer.Model.View;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class FilterUsersListCommand : IRequest<List<UserViewModel>>
    {
        public FilterDto filter;
    }
    public class FilterUserListCommandHandler:IRequestHandler<FilterUsersListCommand,List<UserViewModel>>
    {
        private readonly IConfigurationProvider mapper;
        private readonly IUserRepository userRepository;

        public FilterUserListCommandHandler(IMapper mapper,
           IUserRepository userRepository)
        {
            this.mapper = mapper.ConfigurationProvider;
            this.userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(FilterUsersListCommand request, CancellationToken cancellationToken)
        {
            return userRepository.Sort(request.filter)
               .ProjectTo<UserViewModel>(mapper)
               .ToList()
                ;
        }
    }
}
