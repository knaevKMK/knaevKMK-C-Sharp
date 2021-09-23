using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Data.Models
{
    public class UserApp: IdentityUser
    {
        [Required]
        [MaxLength(50)] 
        public string FullName { get; set; }
    }
}
