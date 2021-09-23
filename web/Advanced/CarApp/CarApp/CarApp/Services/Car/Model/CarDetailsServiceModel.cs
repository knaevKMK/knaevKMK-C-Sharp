
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarApp.Services.Car.Model
{
    public class CarDetailsServiceModel
    {
        public int Id { get; init; }

        public string Brand { get; init; }

        public string Model { get; init; }
        [Display(Name ="Image Url")]
        public string ImageUrl { get; init; }

        public int Year { get; init; }

        public string CategoryName { get; init; }
        [NotMapped]
        public bool IsPublic { get; init; }
    }
}
