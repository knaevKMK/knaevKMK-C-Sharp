
namespace evnServer.Controllers
{
    using AutoMapper;
    using evnServer.Model.View;
    using evnServer.Service.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

  
    public  class DepartmentController:ApiConteroller
    {
        private readonly IMediator mediator;

        public DepartmentController(IMapper mapper, 
            IMediator mediator) : base(mapper)
        {

            this.mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<DepartmentViewModel>>> All() {
            var result =
                mediator.Send(new DepartmentAllQuery());
            return Ok(result.Result);
        }
    }
}
