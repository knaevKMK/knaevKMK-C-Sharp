

namespace evnServer.Service
{
    using evnServer.Model.View;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAll();
    }
}
