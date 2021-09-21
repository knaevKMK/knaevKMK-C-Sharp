namespace CarApp.Models.Car
{
    using CarApp.Services.Car.Model;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class CarFromModel
    {
        [Required]
        [StringLength(20, MinimumLength =2)]
        public string Brand { get; set; }
        [Required]
        [StringLength(30, MinimumLength =2)]
        public string Model { get; set; }
        [Required]
        [StringLength(255,MinimumLength =10)]
        public string Description { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        [Range(1960,2030)]
        public int Year { get; set; }
        public bool IsPublic { get; set; }
        [Display(Name ="Category")]
        public int CategoryId { get; set; }


         public IEnumerable<CarCategoryServiceModel> Categories { get; set; }
    }
}
