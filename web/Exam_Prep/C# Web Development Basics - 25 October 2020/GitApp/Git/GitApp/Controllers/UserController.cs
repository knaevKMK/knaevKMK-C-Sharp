using GitApp.Repositories;
using GitApp.Services;
using GitApp.Views.User.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login(UserLoginDto userDto) {

            return View(userDto);
        }

        [HttpPost]
        public IActionResult LoginPost(UserLoginDto userDto) {
            //todo get token
            try
            {
                string v = userService.Login(userDto);

               //todo v will token 

                // or fault 

                return RedirectToRoute("/Repository/All");
            }
            catch (Exception)
            {
            return RedirectToAction("Login", userDto);

            }

        }
        [HttpGet]
        public IActionResult Register(UserRegisterDto userDto) {

           
            return View(userDto);
        
        }

        public IActionResult RegisterPost(UserRegisterDto userDto) {
            //todo  validate password matchng

            try
            {

                userService.Register(userDto);

                return RedirectToAction("Login");
            }
            catch (Exception)
            {
            return RedirectToAction("Register", userDto);
            }
            
        }
    }
}
