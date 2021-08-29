using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models
{
public    class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }


        public bool IsMechanic { get; set; }


        public virtual ICollection<Car> Cars { get; set; }


    }
}
