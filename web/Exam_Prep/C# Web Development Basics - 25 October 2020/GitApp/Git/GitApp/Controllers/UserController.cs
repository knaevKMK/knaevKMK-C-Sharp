using GitApp.Models;
using GitApp.Repositories;
using GitApp.Services;
using GitApp.Views.User.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(SignInManager<ApplicationUser> signIn, IUserService userService, UserManager<ApplicationUser> manager)
        {
            this.userService = userService;
            _userManager = manager;
            _signInManager = signIn;
            
        }

        [HttpGet]
        public async Task<IActionResult> Login(UserLoginDto userDto) {
            return View(userDto);
        }

        [HttpPost]
        public async  Task<IActionResult> LoginPost(UserLoginDto userDto) {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", userDto);
            }

            var userIsExist = await _userManager.FindByNameAsync(userDto.Username);
            // proverqvash dali sushtestwuva 
            if (userIsExist == null)
            {
                return RedirectToAction("Login", userDto);
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(userIsExist, userDto.Password);
            if (!passwordCheck)
            {
                return RedirectToAction("Login", userDto);
            }
            await _signInManager.SignInAsync(userIsExist, true);
            return RedirectToAction("All", "Repository");
            // Session :) 
            this.HttpContext.Session.SetString("LOGIN", "LOGNAT SI UE");
                  }
        [HttpGet]
        public IActionResult Register(UserRegisterDto userDto) {
            return View(userDto);
        }

        public IActionResult RegisterPost(UserRegisterDto userDto) {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register", userDto);
            }

           // _userManager.

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
