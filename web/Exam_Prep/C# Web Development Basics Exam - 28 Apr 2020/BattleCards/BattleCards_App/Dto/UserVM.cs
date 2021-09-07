using BattleCards_App.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Dto
{
    using static FieldConstatnts;
    public class UserVM
    {
        [Required]
        [MinLength(USER_USERNAME_MIN_LENGHT)]
        [MaxLength(USER_USERNAME_MAX_LENGHT)]
        public string Username { get; set; }
    }

    public class UserLoginVM:UserVM
    {
        
        [Required]
        [MinLength(USER_PASSWORD_MIN_LENGHT)]
        [MaxLength(USER_PASSWORD_MAX_LENGHT)]
        public string Password { get; set; }

    }

    public class UserRegisterMV :UserLoginVM
    {
        [RegularExpression(USER_EMAIL_REGEX)]
        public string Email { get; set; }
        [Required]
        [MinLength(USER_PASSWORD_MIN_LENGHT)]
        [MaxLength(USER_PASSWORD_MAX_LENGHT)]
        public string ConfirmPassword { get; set; }
    }
}
