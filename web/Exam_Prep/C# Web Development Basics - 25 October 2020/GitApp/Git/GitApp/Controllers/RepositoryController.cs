using GitApp.Views.Repository.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Controllers
{
    public class RepositoryController : Controller
    {
        // GET: RepositoryController
        public ActionResult All() {
            return View();
        }
        // GET: RepositoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepositoryController/Create
        public ActionResult Create(RepositoryCreateDto repositoryDto)
        {
            return View(repositoryDto);
        }

        // POST: RepositoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(RepositoryCreateDto repositoryDto)
        {
          
               //validate adn add todb
              //  return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", repositoryDto) ;
        }
    }
}
