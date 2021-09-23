namespace CarApp.Controllers
{
    using CarApp.Models.Car;
    using CarApp.Services.Car;
    using CarApp.Services.Car.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }


        public IActionResult All([FromQuery] AllCarsQueryModel query)
        {
            CarQueryServiceModel queryResult = this.carService.All(
                query.Brand,
                query.SearchTerm,
              query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsPerPage,
                true);

            IEnumerable<string> carBrands = this.carService.AllBrands();

            query.Brands = carBrands;
            query.TotalCars = queryResult.TotalCars;
            query.Cars = queryResult.Cars;

            return View(query);
        }
        public IActionResult Details(int id) {
            var car = this.carService.GetCarById(id);
            if (car==null)
            {
                return BadRequest();
            }
            return View(car);
        }
        public IActionResult AddCar()
        {
            return View(new CarFromModel {Categories=carService.AllCategories() });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddCar(CarFromModel car)
        {
            if (!this.carService.CategoryExists(car.CategoryId))
            {
                ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
            }
            if (!ModelState.IsValid)
            {
                car.Categories = this.carService.AllCategories();
            return View(car);
            }

            //ToDo 
           int carId= this.carService.Create(car);
          
         //TempData[GlobalMessageKey] = "You car was added and is awaiting for approval!";

            return RedirectToAction("Details", new { id = carId });
         //   return RedirectToAction("Index", "Home");
        }
    }
}
