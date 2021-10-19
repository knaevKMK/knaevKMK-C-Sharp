
namespace ex.Services
{
    using AutoMapper;
    using ex.Data;
   

    public class DepartmentService : IDepartmentService
    {

        private readonly ApplicationDbContext data;
        private readonly IConfigurationProvider mapper;

        public object DapermentEnum { get; private set; }

        public DepartmentService(IMapper mapper, ApplicationDbContext data)
        {
            this.mapper =(mapper.ConfigurationProvider);
            this.data = data;
        }

     
      
    }
}
