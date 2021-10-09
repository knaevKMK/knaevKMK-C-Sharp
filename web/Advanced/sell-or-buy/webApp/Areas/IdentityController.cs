using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using webApp.Areas.Identity.BindingModels;
using webApp.Areas.Identity.Model;

namespace webApp.Areas
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<UserApp> userManager;

        public IdentityController(IdentityService identityService
           // ,            UserManager<UserApp> userManager
            )
        {
            this.identityService = identityService;
         //   this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register(UserRegisterBindingModel model) {
            Console.WriteLine();
            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterConfirm(UserRegisterBindingModel model) {
            Console.WriteLine();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //validate model
            //

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login(UserLoginBindingModel model) {
            return View(model);
        }

        [HttpPost]
        public IActionResult LoginConfirm(UserLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          

            return RedirectToAction("Index","Home");
        }
    }
}
