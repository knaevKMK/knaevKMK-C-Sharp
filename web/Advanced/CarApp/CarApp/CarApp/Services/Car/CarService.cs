using CarApp.Services.Car.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Services.Car
{
    public class CarService : ICarService
    {
        public IEnumerable<CarCategoryServiceModel> AllCategories()
        {
            throw new NotImplementedException();
        }

        public bool CategoryExists(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
