using BattleCards_App.Dto;
using BattleCards_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login(UserLoginVM user) {
            if (user.Username==null)
            {
                return View();
            }
            user.Password = "";
            return View(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginPost(UserLoginVM user) {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }
                _userService.Login(user);

                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
               
                return RedirectToAction("Login", user);
               
            }
        
        }


        [HttpGet]
        public IActionResult Register(UserRegisterMV user) {

            if (user.Username==null)
            {
            return View();
            }

            user.Password = "";
            user.ConfirmPassword = "";
            return View(user);
        }

        [HttpPost]
        public IActionResult RegisterPost(UserRegisterMV user) {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }
                _userService.Register(user);
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
               
                return RedirectToAction("Register",user);
            }
        }
    }
}
