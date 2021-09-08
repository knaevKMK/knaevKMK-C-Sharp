using BattleCards_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Controllers
{
    public class CardsController : Controller
    {
        private readonly CardService _cardService;

        public CardsController(CardService cardService)
        {
            _cardService = cardService;
        }



        // GET: CardsController
        public IActionResult All() {


            ICollection<Dto.CardVM> cardVMs = _cardService.GetAllCards();
            return View(cardVMs);
        }

        public IActionResult Collection() {

            ICollection<Dto.CardVM> cardVMs = _cardService.GetAllCards(User.Identity.Name);
            return View(cardVMs);
        }
        // GET: CardsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CardsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CardsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CardsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CardsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
