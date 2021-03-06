using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Services;
using WebApplication3.Views.ImoprtDto;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;
        private readonly ISupplerServce supplerServce;
        private readonly IPartService   partServce;

        private readonly ILogger<HomeController> logger;

        public HomeController(ICarService carService, ISupplerServce supplerServce, IPartService partServce, ILogger<HomeController> logger)
        {
            this.carService = carService;
            this.supplerServce = supplerServce;
            this.partServce = partServce;
            this.logger = logger;
        }
      
        
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cars(int? page) {
           
            ICollection<Views.ImoprtDto.CarDto> carDtos = carService.AllCars();
            return View(carDtos);
        }

        public IActionResult Details(int id) {
            Views.ImoprtDto.CarDto carDto = carService.GetCarById(id);
            return View(carDto);
        }
        [HttpGet]
        public IActionResult Edit(int id) {

            Views.ImoprtDto.CarDto carDto = carService.GetCarById(id);
            return View(carDto);
        }

        [HttpPost]
        public IActionResult EditPost(CarDto car) {

            //ToDo update entity
            car= carService.UpdateCar(car);

            var id = new { car.Id };
            return RedirectToAction("Details",id);
        }


        [HttpGet]
        public IActionResult Create(CarDto car) {
      
            return View(car);
        }

        [HttpPost]
        public IActionResult CreatePost(CarDto car) {
            //TODO valdate
            if (car.make==null || car.model==null|| car.travelledDistance<0)
            {
            return RedirectToAction("Create", car);
            }
        
            CarDto carDto = carService.AddCar(car);
             return View("Details",car);
        }


       
        public IActionResult Delete(int id) {
            CarDto carDto = carService.DeleteCar(id); 
            
            if (carDto==null)
            {
               // Return error msg 
            }
            return RedirectToAction("Cars");
        }
        public IActionResult Privacy()
        {
            if (!supplerServce.IsImported())
            {
                supplerServce.ImportFromJson();
            }
            if (!partServce.IsImported())
            {
                partServce.ImportFromJson();
            }
           if (!carService.IsImported())
          {
             carService.ImportFromJson();
            }

            return RedirectToAction("Index");
        }

       

    

        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
