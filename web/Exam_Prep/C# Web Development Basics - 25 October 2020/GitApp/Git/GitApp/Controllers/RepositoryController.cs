using GitApp.Services;
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

        private readonly IRepositoryService repositoryServce;

        public RepositoryController(IRepositoryService repositoryServce)
        {
            this.repositoryServce = repositoryServce;
        }



        // GET: RepositoryController
        public ActionResult All() {

            ICollection<RepositoryListOutDto> repositoryListOutDtos = repositoryServce.GetAll();

            return View(repositoryListOutDtos);
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
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", repositoryDto);
            }

            repositoryServce.Add(repositoryDto);
            return RedirectToAction("All");
        }


    }
}
