namespace EvnWithAngular.Controllers
{
    using AutoMapper;
    using EvnWithAngular.Models.Views;
    using EvnWithAngular.Services;
   using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("/department")]
    public class DepartmentController : ApiController
    {

        private readonly IDepartmentService departmentService;
        public DepartmentController(IMapper mapper, IDepartmentService departmentService) : base(mapper)
        {
            this.departmentService = departmentService;
        }
        [HttpGet]
        [Route("/all")]
        public async Task<ActionResult<List<DepartmentViewModel>>> All()
        {

            var result = this.departmentService.getAll();
            return await Task.FromResult(result);
        }
    }
}
