
namespace evnServer.Service.Queries
{
    using evnServer.Model.Binding;
    using evnServer.Model.View;
using MediatR;
using System.Collections.Generic;
    public class FilterUsersListQuery : IRequest<List<UserViewModel>> {

        public FilterDto filter;

       
    }
}
