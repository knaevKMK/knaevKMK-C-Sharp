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
        [HttpGet]
        public IActionResult Login(UserLoginDto userDto) {
            return View(userDto);
        }

        [HttpPost]
        public IActionResult LoginPost(UserLoginDto userDto) {
            //todo get token
            return RedirectToAction("Login", userDto);
        }
        [HttpGet]
        public IActionResult Register(UserRegisterDto userDto) {

            return View(userDto);
        
        }

        public IActionResult RegisterPost(UserRegisterDto userDto) {
            //todo add user to db, validate
            return RedirectToAction("Register", userDto);
        }
    }
}
