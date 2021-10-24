
namespace evnServer.Data.Repositories
{
    using evnServer.Model.Entity;
    using System.Linq;

    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext data) : base(data)
        {
        }

        public Department GetDepartmentByName(string departmentName)
        {
            return base.data.Departments.FirstOrDefault(d => d.Name == departmentName);
        }

    }
}
