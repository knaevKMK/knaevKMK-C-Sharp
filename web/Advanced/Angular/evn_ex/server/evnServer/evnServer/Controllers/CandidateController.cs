
namespace evnServer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using evnServer.Model.Binding;
    using evnServer.Model.Service;
    using evnServer.Model.View;
    using evnServer.Service;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

   
    public class CandidateController: ApiConteroller { 

        private readonly IUserService userService;


        public CandidateController(IUserService userService, IMapper mapper) :base(mapper)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<UserViewModel>>> All()
        {

            var result = this.userService.All();
            return await Task.FromResult(result);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(UserCreateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest();
            }

            try
            {
                var result = await this.userService.Create(base.mapper.CreateMapper().Map<UserServiceModel>(userDto));

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<List<UserViewModel>>> filter(FilterDto filter) {


            var result =  this.userService.filter(filter);
            return Ok(result);
        }
    }
}
