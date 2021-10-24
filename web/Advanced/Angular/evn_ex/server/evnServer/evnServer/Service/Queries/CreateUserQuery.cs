

namespace evnServer.Service.Queries
{
using evnServer.Model.Service;
using MediatR;
    public class CreateUserQuery:IRequest<int>
    {
        public UserServiceModel userServiceModel;
    }
}
