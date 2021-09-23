using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Services.Car.Model
{
    public class CarQueryServiceModel
    {

        public int CurrentPage { get; init; }

        public int CarsPerPage { get; init; }

        public int TotalCars { get; init; }

        public IEnumerable<CarServiceModel> Cars { get; init; }
    }
}
