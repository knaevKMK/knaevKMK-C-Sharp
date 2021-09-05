using GitApp.Services;
using GitApp.Views.Commit.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Controllers
{
    public class CommitController : Controller
    {
        //deteto reve moment
        //ок taka celiq fokus tuka e ne ti da se grizhish za userite a microsoft
        /// <summary>
        /// smisyl po-umni sa ot nas napisali sa si identity frameowkmoment che deteto
        /// 
        /// ок
        /// ще го разуча как се бачка с него da imash usermanager
        /// същото ли  е като правиш проекта  зададеш identty?
        /// </summary>
        private readonly ICommitService commitService;

        public CommitController(ICommitService commitService)
        {
            this.commitService = commitService;
        }

        public IActionResult All() {
            ICollection<CommitListOutDto> commitListOutDtos = commitService.GetAll();
            return View(commitListOutDtos);
        }

        public IActionResult Create(CommitCreateDto commitDto) {
            return View(commitDto);
        }

        public IActionResult CreatePost(CommitCreateDto commitDto) {
            if (!ModelState.IsValid)
            {
            return RedirectToAction("Create", commitDto);
            }
            CommitCreateDto commitCreateDto = commitService.Add(commitDto);
            return RedirectToAction("All", commitCreateDto);
        }
    }
}
