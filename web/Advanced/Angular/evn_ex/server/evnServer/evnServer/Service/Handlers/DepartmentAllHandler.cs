
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
    public class DepartmentAllHandler : IRequestHandler<DepartmentAllQuery, List<DepartmentViewModel>>
    {

        private readonly IDepartmentRepository departmentRepository;
        private readonly IConfigurationProvider mapper;

        public DepartmentAllHandler(IDepartmentRepository departmentRepository, IConfigurationProvider mapper)
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
