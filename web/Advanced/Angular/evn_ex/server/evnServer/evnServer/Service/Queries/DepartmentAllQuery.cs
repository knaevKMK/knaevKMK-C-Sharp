
namespace evnServer.Service.Queries
{
using evnServer.Model.View;
using MediatR;
using System.Collections.Generic;
    public record DepartmentAllQuery: IRequest<List<DepartmentViewModel>>;
}
