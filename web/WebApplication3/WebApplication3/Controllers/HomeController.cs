using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Services;
using WebApplication3.Views.ExportDto;
using WebApplication3.Views.ImportDto;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _carService = carService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Car(int id) {
            CarExportDto car = _carService.GetCarById(id);
            return View(car);
        }
        //public IActionResult AllCars() {
        //    ICollection<CarExportDto> cars = _carService.AllCars();
        //    return View(cars);
        //}

      [HttpGet]
        public IActionResult AddCar_get(CarImportDto carDto)
        {

                return View(carDto);
           }

        [HttpPost] 
    
        public IActionResult AddCar_post(CarImportDto carDto) {


             if (!ModelState.IsValid)
            {
                carDto.Model = "BMW";
                return RedirectToAction("AddCar_get");
            }
            
            //  add dto to db and redirect
            //   return RedirectToAction("AllCars");
            return RedirectToAction("Index");
        }

        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
