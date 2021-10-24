
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
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<UserViewModel>>
    {
        private readonly IConfigurationProvider _mapper;
        private readonly IUserRepository userRepository;


        public GetUserListHandler(
           IMapper mapper, 
           IUserRepository userRepository)
        {
            _mapper = mapper.ConfigurationProvider;
            this.userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
          return   userRepository.GetAll()
                                   .ProjectTo<UserViewModel>(_mapper)
                                    .ToList();
        }
    }
}
