
namespace EvnWithAngular.Services
{
using EvnWithAngular.Models.Views;
    using System.Collections.Generic;

    public interface IDepartmentService
    {
        List<DepartmentViewModel> getAll();
    }
}
