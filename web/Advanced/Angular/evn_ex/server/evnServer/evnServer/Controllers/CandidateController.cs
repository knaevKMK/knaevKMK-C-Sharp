
namespace evnServer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using evnServer.Model.Binding;
    using evnServer.Model.Service;
    using evnServer.Model.View;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using evnServer.Validation;
    using FluentValidation.Results;
    using FluentValidation.AspNetCore;
    using MediatR;
    using evnServer.Service.Queries;

    public class CandidateController: ApiConteroller { 

        private readonly UserCreatDtoValidation userModelValidator;
        private readonly IMediator mediator;

        public CandidateController(
            IMapper mapper, 
            UserCreatDtoValidation userModelValidator, 
            IMediator mediator) 
                : base(mapper)
        {
            this.userModelValidator = userModelValidator;
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<UserViewModel>>> All()
        {

            var result = this.mediator.Send(new GetUserListQuery());
            return Ok(result.Result);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(UserCreateDto userDto)
        {

                ValidationResult validationResult = this.userModelValidator.Validate(userDto);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState, null);
                return BadRequest(validationResult.Errors);
            }
                try
                {
                var  result= 
              mediator.Send(new CreateUserQuery {
                 userServiceModel= base.mapper.CreateMapper().Map<UserServiceModel>(userDto)});

                return Created("Created",result.Result);
                }
                catch (Exception)
                {

                    return BadRequest();
                }

         }
          
        
        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<List<UserViewModel>>> filter(FilterDto _filter) {

            var result = await   this.mediator.Send(new FilterUsersListQuery {filter= _filter });
            return Ok(result);
        }
    }
}
