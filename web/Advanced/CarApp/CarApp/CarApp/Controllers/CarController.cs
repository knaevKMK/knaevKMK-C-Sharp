namespace CarApp.Controllers
{
    using CarApp.Models.Car;
    using Microsoft.AspNetCore.Mvc;
    public class CarController : Controller
    {
        //public IActionResult AllCars()
        //{
        //    return View();
        //}
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(CarFromModel car)
        {

            if (!ModelState.IsValid)
            {

            return View(car);
                            }

            return RedirectToAction("Index", "Home");
        }
    }
}
