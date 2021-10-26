
namespace evnServer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using evnServer.Model.Binding;
    using evnServer.Model.View;
    using Microsoft.AspNetCore.Mvc;
    using evnServer.Validation;
    using FluentValidation.Results;
    using FluentValidation.AspNetCore;
    using evnServer.Service;

    public class CandidateController : ApiConteroller {

        private readonly UserCreatDtoValidation userModelValidator;
        private readonly IUserService userService;
        public CandidateController(

            UserCreatDtoValidation userModelValidator,
             IUserService userService)
        {
            this.userModelValidator = userModelValidator;
            this.userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<UserViewModel>>> All()
        {

            var result = await this.userService.GetAll();
            return Ok(result);
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
                var result = await
                    this.userService.Create((userDto));

                return Created("Created", result);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<List<UserViewModel>>> filter(FilterDto filter) {
            var result = await this.userService.Filter(filter);
            return Ok(result);
        }
        [HttpGet]
        [Route("sort")]
        public async Task<ActionResult<List<UserViewModel>>> Sort([FromQuery]String query) {
            string[] token = query.Split(" ");
            SortBindDto _sort = new SortBindDto() { SortBy = token[0], Arrow = token[1] };
            var result = await this.userService.Sort(_sort);
            return Ok(result);
        }
    }
}
