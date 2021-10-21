
namespace evnServer.Controllers
{
    using AutoMapper;
    using evnServer.Model.View;
    using evnServer.Service;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

  
    public  class DepartmentController:ApiConteroller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IMapper mapper, IDepartmentService departmentService) :base(mapper)
        {
          
            this.departmentService = departmentService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<DepartmentViewModel>>> All() {
            var result = this.departmentService.getAll();
            return Ok(result);
        }
    }
}
