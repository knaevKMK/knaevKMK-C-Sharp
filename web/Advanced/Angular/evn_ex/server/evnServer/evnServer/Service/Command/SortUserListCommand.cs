


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

    public class SortUserListCommand: IRequest<List<UserViewModel>>
    {
        public SortBindDto sort;
    }

    public class SortUserListCommandHandler : IRequestHandler<SortUserListCommand, List<UserViewModel>>{

        private readonly IConfigurationProvider mapper;
        private readonly IUserRepository userRepository;

        public SortUserListCommandHandler(IConfigurationProvider mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(SortUserListCommand request, CancellationToken cancellationToken)
        {
        return    this.userRepository.SortBy(request.sort)
                  .ProjectTo<UserViewModel>(mapper)
                   .ToList();
        }
    }
}
