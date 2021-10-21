namespace EvnWithAngular.Services.impl
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EvnWithAngular.Data;
    using EvnWithAngular.Models.Views;
    using System.Collections.Generic;
    using System.Linq;
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext data;
        private readonly IConfigurationProvider mapper;
        public DepartmentService(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper.ConfigurationProvider;
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
