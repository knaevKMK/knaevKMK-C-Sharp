
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
    using evnServer.Validation;
    using FluentValidation.Results;
    using FluentValidation;
    using FluentValidation.AspNetCore;

    public class CandidateController: ApiConteroller { 

        private readonly IUserService userService;
        private readonly UserCreatDtoValidation userModelValidator;


        public CandidateController(IUserService userService, IMapper mapper, UserCreatDtoValidation userModelValidator) :base(mapper)
        {
            this.userService = userService;
            this.userModelValidator = userModelValidator;
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

                ValidationResult validationResult = this.userModelValidator.Validate(userDto);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState, null);
                return Ok(validationResult);
            }
                try
                {
                 int  result= await this.userService.Create(base.mapper.CreateMapper()
                           .Map<UserServiceModel>(userDto));

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
