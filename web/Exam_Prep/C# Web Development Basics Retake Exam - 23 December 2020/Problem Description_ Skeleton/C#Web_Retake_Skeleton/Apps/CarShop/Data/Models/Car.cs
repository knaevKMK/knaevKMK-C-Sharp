using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarShop.Data.Models
{
public    class Car
    {
        public Car()
        {
            this.Issues = new HashSet<Issue>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        [Range(1900, 2022)]
        public int Year { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        [RegularExpression("")]
        public string PlateNumber { get; set; }
        [Required]
        [ForeignKey("Owner")]
        public int OwnerId{ get; set; }
        public User Owner { get; set; }


        public virtual ICollection<Issue> Issues { get; set; }
    }
}
