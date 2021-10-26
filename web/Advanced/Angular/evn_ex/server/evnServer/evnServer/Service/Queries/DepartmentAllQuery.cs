
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
    public record DepartmentAllQuery: IRequest<List<DepartmentViewModel>>;
    public class DepartmentAllQueryHandler : IRequestHandler<DepartmentAllQuery, List<DepartmentViewModel>>
    {

        private readonly IDepartmentRepository departmentRepository;
        private readonly IConfigurationProvider mapper;

        public DepartmentAllQueryHandler(IDepartmentRepository departmentRepository, IConfigurationProvider mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public async Task<List<DepartmentViewModel>> Handle(DepartmentAllQuery request, CancellationToken cancellationToken)
        {
            return this.departmentRepository.GetAll()
                 .ProjectTo<DepartmentViewModel>(mapper)
                 .ToList();
        }
    }
}
