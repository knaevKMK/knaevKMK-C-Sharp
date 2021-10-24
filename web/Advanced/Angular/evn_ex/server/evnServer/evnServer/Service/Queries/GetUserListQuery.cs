
namespace evnServer.Service.Queries
{
    using evnServer.Model.View;
    using MediatR;
using System.Collections.Generic;
    public record GetUserListQuery:IRequest<List<UserViewModel>>;
}
