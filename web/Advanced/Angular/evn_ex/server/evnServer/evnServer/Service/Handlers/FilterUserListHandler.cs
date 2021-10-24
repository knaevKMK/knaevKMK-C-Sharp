namespace evnServer.Service.Handlers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using evnServer.Data.Repositories;
    using evnServer.Model.View;
    using evnServer.Service.Queries;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public class FilterUserListHandler:IRequestHandler<FilterUsersListQuery,List<UserViewModel>>
    {
        private readonly IConfigurationProvider mapper;
        private readonly IUserRepository userRepository;

        public FilterUserListHandler(IMapper mapper,
           IUserRepository userRepository)
        {
            this.mapper = mapper.ConfigurationProvider;
            this.userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(FilterUsersListQuery request, CancellationToken cancellationToken)
        {
            return userRepository.Sort(request.filter)
               .ProjectTo<UserViewModel>(mapper)
               .ToList()
                ;
        }
    }
}
