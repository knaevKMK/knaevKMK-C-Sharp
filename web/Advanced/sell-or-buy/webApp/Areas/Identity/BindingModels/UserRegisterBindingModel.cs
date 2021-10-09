using System;
using System.Collections.Generic;
using System.Linq;
namespace webApp.Areas.Identity.BindingModels
{
    public class UserRegisterBindingModel
    {
        
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


    }
}
