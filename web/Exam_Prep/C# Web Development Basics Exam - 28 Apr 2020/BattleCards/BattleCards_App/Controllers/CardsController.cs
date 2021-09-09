using BattleCards_App.Dto;
using BattleCards_App.Models;
using BattleCards_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Controllers
{
    [Authorize]
    public class CardsController : Controller
    {
        private readonly CardService _cardService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<RegisterModel> _logger;


        public CardsController(CardService cardService, SignInManager<User> signInManager, ILogger<RegisterModel> logger, UserManager<User> userManager)
        {
            _cardService = cardService;
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }



        public IActionResult All() {


            ICollection<Dto.CardVM> cardVMs = _cardService.GetAllCards();
            return View(cardVMs);
        }

        public async Task<IActionResult> Collection() {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            ICollection<Dto.CardVM> cardVMs = _cardService.GetAllCards(user.Id);
            return View(cardVMs);
        }

        public IActionResult RemoveFromCollection() {
            return Ok();
        }
      
        
        [HttpGet]
        public IActionResult Create(CardVM card) {

            return View(card);
        }
        // POST: CardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePost(CardVM card)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", card);
            }
            try
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);

                _cardService.CreateCard(card,user);
                return RedirectToAction("All");
            }
            catch
            {
                return RedirectToAction("CreateGet",card);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddToCollection(string id)
        {

            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!_cardService.IsInMyCollection(id, user.Id))
            {
            _cardService.AddToCollection(id, user.Id);
            }
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCollection(string id) {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            _cardService.RemoveFromCollection(id, user.Id);
            return RedirectToAction("Collection");
        }

    }
}
