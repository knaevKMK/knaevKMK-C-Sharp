

namespace evnServer.Data.Repositories
{
using evnServer.Model.Entity;
    public interface IDepartmentRepository:IRepository<Department>
    {
        Department GetDepartmentByName(string departmentName);

    }
}
