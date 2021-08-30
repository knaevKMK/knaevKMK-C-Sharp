using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Models.Enum;
using WebApplication3.Views.ExportDto;

namespace WebApplication3.Controllers
{
   // [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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
        public IActionResult Car() {
            var car = new CarExportDto {

                Manufacturer = "Mercedes",
                Model = "E 500",
                Engine = EngineEnum.Petrol.ToString(),
                Transmision = TransmisionEnum.Automatic.ToString(),
                type = TypeCabinEnum.Sedan.ToString(),
                RegisterOn = DateTime.UtcNow,
                ImageUrl= "https://pictures.topspeed.com/IMG/jpg/201208/mercedes-benz-e500-b-4.jpg"
            };
           

            return View(car);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
