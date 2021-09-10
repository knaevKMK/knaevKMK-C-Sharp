using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokerApp.Models;
using PokerApp.ModelsView;
using PokerApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameService _gameService;


        public HomeController(ILogger<HomeController> logger, GameService gameService)
        {
            _logger = logger;
          _gameService = gameService;
        }



        public IActionResult Index(GameVM game )
        {
            if (game.Credit>=game.Bet)
            {
            game= _gameService.Play(game);

            }

            return View(game);
        }

     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
