namespace EvnWithAngular.Controllers
{
    using AutoMapper;
    using EvnWithAngular.Models.Binding;
    using EvnWithAngular.Models.Service;
    using EvnWithAngular.Models.Views;
    using EvnWithAngular.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CandidateController : ApiController
    {

        private readonly IUserService userService;

        public CandidateController(IMapper mapper, IUserService userService) : base(mapper)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("/all")]
        public async Task<ActionResult<List<UserViewModel>>> All(){

            var result =  this.userService.All();
            return await Task.FromResult(result);
        }
        [HttpPost]
        [Route("/create")]
        public async Task<ActionResult> Create(UserCreateDto userDto) {
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


    }
}
