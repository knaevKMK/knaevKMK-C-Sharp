
namespace ex.Controllers
{
    using AutoMapper;
    using ex.Models.Binding;
    using ex.Models.Service;
    using ex.Models.View;
    using ex.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    public class CandidateController : Controller
    {
        private readonly IUserService userService;
        private readonly IConfigurationProvider _mapper;
        public CandidateController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this._mapper = mapper.ConfigurationProvider;
        }

       
        public IActionResult addUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addUserConfirm(UserAddDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);

            }

            UserServiceModel userServiceModel = _mapper.CreateMapper().Map<UserServiceModel>(userDto);
            this.userService.add(userServiceModel);
            return RedirectToAction("allUsers");
        }

        public IActionResult allUsers()
        {
            List<UserViewModel> users = this.userService.getAll();
            return View(users);
        }

        public IActionResult sort(FilterDto sort)
        {
            List<UserViewModel> users = this.userService.getAll(sort);
            return View("allUsers", users);
        }

    }
}
