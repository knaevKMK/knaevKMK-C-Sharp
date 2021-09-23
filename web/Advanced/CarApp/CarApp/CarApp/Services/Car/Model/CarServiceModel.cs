using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Services.Car.Model
{
    public class CarServiceModel
    {
        public int Id { get; init; }

        public string Brand { get; init; }

        public string Model { get; init; }

        public string ImageUrl { get; init; }

        public int Year { get; init; }

        public string CategoryName { get; init; }

        public bool IsPublic { get; init; }
        public string Description { get; init; }

        public int CategoryId { get; init; }

        public int DealerId { get; init; }

        public string DealerName { get; init; }

        public string UserId { get; set; }
    }
}
