using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarShop.Data.Models
{
public    class Issue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [DataType("text")]
        public string Description { get; set; }
       
        public bool IsFixed { get; set; }
       [Required]
       [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
