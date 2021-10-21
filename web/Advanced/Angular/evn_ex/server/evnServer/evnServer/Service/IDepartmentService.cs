namespace evnServer.Service
{
using System.Collections.Generic;
    using evnServer.Model.View;
 public   interface IDepartmentService
    {

        List<DepartmentViewModel> getAll();
    }
}
