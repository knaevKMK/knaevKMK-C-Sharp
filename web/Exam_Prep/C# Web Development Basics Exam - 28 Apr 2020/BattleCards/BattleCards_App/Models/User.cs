using BattleCards_App.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards_App.Models
{
    using static FieldConstatnts;
    public class User: IdentityUser
    {
        public User()
        {
            UserCards = new HashSet<UserCard>();
        }

        //[Key]
        //[MaxLength(KEY_MAX_LENGHT)]
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        //[Required]
        //[MinLength(USER_USERNAME_MIN_LENGHT)]
        //[MaxLength(USER_USERNAME_MAX_LENGHT)]
        //public string Username { get; set; }
        //[Required]
        //    public string Email { get; set; }
      //  [Required]
        //[MinLength(USER_PASSWORD_MIN_LENGHT)]
        //[MaxLength(USER_PASSWORD_MAX_LENGHT)]
        //public string Password { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }

    }
}
