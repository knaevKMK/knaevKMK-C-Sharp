
namespace evnServer.Service.impl
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using evnServer.Data;
    using evnServer.Model.View;

    public class DepartmentService: IDepartmentService
    {
        private readonly IConfigurationProvider mapper;
        private readonly ApplicationDbContext data;

        public DepartmentService(IConfigurationProvider mapper, ApplicationDbContext data)
        {
            this.mapper = mapper;
            this.data = data;
        }

        public List<DepartmentViewModel> getAll()
        {
            return this.data.Departments
                 .ProjectTo<DepartmentViewModel>(mapper)
                 .ToList();
        }
    }
}
