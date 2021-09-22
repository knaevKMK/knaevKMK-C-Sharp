namespace CarApp.Controllers
{
    using CarApp.Models.Car;
    using CarApp.Services.Car;
    using Microsoft.AspNetCore.Mvc;
    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }




        //public IActionResult AllCars()
        //{
        //    return View();
        //}
        public IActionResult AddCar()
        {
            return View(new CarFromModel {Categories=carService.AllCategories() });
        }
        [HttpPost]
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
            //map dto to entity
           // TempData[GlobalMessageKey] = "You car was added and is awaiting for approval!";

         //   return RedirectToAction(nameof(Details), new { id = carId, information = car.GetInformation() });
            return RedirectToAction("Index", "Home");
        }
    }
}
