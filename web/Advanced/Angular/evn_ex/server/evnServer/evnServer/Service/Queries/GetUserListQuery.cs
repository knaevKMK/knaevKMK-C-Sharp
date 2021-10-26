
namespace evnServer.Service.Queries
{
    using evnServer.Model.View;
    using MediatR;
    using System.Collections.Generic;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using evnServer.Data.Repositories;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public record GetUserListQuery:IRequest<List<UserViewModel>>;

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserViewModel>>
    {
        private readonly IConfigurationProvider _mapper;
        private readonly IUserRepository userRepository;


        public GetUserListQueryHandler(
           IMapper mapper,
           IUserRepository userRepository)
        {
            _mapper = mapper.ConfigurationProvider;
            this.userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return userRepository.GetAll()
                                     .ProjectTo<UserViewModel>(_mapper)
                                      .ToList();
        }
    }
}
