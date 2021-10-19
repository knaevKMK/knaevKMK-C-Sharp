namespace ex.Controllers
{
using AutoMapper;
using ex.Models;
using ex.Models.Binding;
using ex.Models.Service;
using ex.Models.View;
using ex.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public HomeController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = configMapper(mapper);
        }

        private IMapper configMapper(IMapper mapper)
        {
            var config = new MapperConfiguration(c => c.CreateMap<UserAddDto, UserServiceModel>());
           return config.CreateMapper();
        }

        public IActionResult Index()
        {
            return RedirectToAction("allUsers");
           // return View();
        }

        [HttpGet]
        
        public IActionResult addUser() {
            return View();
        }
        [HttpPost]
        public IActionResult addUserConfirm(UserAddDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);

            }

            UserServiceModel userServiceModel = mapper.Map<UserAddDto, UserServiceModel>(userDto);
            this.userService.add(userServiceModel);
            return RedirectToAction("allUsers");
        }
                
            
          public IActionResult allUsers() {
            List<UserViewModel>  users = this.userService.getAll();
               return View(users);
        }

       public IActionResult sort(FilterDto sort) {
            List<UserViewModel> users = this.userService.getAll(sort);
            return View("allUsers",users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
