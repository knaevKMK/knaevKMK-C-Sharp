using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Views.User.Dto
{
    public class UserRegisterDto
            {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Username must least than 5 symbols")]
        [MaxLength(20, ErrorMessage = "Username must less than 20 symbols")]
        public string Username { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",ErrorMessage ="The email s not valid")]
        public string Email { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Password must least than 6 symbols")]
        [MaxLength(20, ErrorMessage = "Password must less than 20 symbols")]
        public string Password { get; set; }

        [Required]
       
        public string ConfirmPassword { get; set; }
    }
}
