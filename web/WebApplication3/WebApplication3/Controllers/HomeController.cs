using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Services;

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
