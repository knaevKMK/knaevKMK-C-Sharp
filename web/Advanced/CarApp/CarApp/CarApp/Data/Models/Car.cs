using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Data.Models
{
    public class Car
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(30)]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public bool IsPublic { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
