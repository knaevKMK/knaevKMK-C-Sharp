
namespace evnServer.Controllers
{
    using AutoMapper;
    using evnServer.Model.View;
    using evnServer.Service;
    using evnServer.Service.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

  
    public  class DepartmentController:ApiConteroller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(
        IDepartmentService departmentService)
        {
            this.departmentService = departmentService;

        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<DepartmentViewModel>>> All() {
            var result = await this.departmentService.GetAll();
            return Ok(result);
        }
    }
}
