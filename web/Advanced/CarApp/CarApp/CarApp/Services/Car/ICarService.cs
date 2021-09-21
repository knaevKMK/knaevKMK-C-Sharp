namespace CarApp.Services.Car
{
    using CarApp.Services.Car.Model;
    using System.Collections.Generic;
    interface ICarService
    {

        IEnumerable<CarCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);
    }
}
