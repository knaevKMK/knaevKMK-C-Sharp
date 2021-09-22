namespace CarApp.Services.Car
{
    using CarApp.Models.Car;
    using CarApp.Services.Car.Model;
    using System.Collections.Generic;
   public interface ICarService
    {

        IEnumerable<CarCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);
        int Create(CarFromModel car);
    }
}
