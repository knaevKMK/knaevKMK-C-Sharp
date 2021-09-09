using BattleCards_App.Dto;
using BattleCards_App.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<RegisterModel> _logger;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager
            , ILogger<RegisterModel> logger
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }



        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login(UserLoginVM user) {
            if (user.Username == null)
            {
                return View();
            }
            user.Password = "";
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> LoginPost(UserLoginVM user) {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", user);
            }
            User _user = _userManager.Users.FirstOrDefault(u => u.UserName == user.Username);
            if (_user == null)
            {
                ModelState.AddModelError(string.Empty, "User With this username does not exist");
                return RedirectToAction("Login", user);
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult =
            await _signInManager.PasswordSignInAsync(_user.UserName, user.Password, false, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            return RedirectToAction("Login", user);

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(UserRegisterMV user) {

            if (user.Username == null)
            {
                return View();
            }

            user.Password = "";
            user.ConfirmPassword = "";
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPost(UserRegisterMV user) {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register", user);
            }

            if (!user.Password.Equals(user.ConfirmPassword))
            {
                ModelState.AddModelError(string.Empty, "Passwords not matched");
                return RedirectToAction("Register", user);
            }
            if (await _userManager.FindByNameAsync(user.Username) != null)
            {
                ModelState.AddModelError(string.Empty, "Username allredy exist");
                return RedirectToAction("Register", user);
            }

            if (await _userManager.FindByEmailAsync(user.Email) != null)
            {
                ModelState.AddModelError(string.Empty, "Emial allredy exist");
                return RedirectToAction("Register", user);
            }

            Models.User _user = new Models.User()
            {
                UserName = user.Username,
                Email = user.Email,
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true
            };
            IdentityResult identityResult = await _userManager.CreateAsync(_user, user.Password);
            await _userManager.AddToRoleAsync(_user,"Super Admin");
            if (identityResult.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                return RedirectToAction("Login", new UserLoginVM() { Username = _user.UserName, Password = "" });

            }
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return RedirectToAction("Register", user);
        }

        [HttpGet]
       [Authorize]
        public async Task<IActionResult> LogOut() {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }
    }
}
