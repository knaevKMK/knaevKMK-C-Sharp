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
        public IActionResult All() {

            return View();
        }

        public IActionResult Create(CommitCreateDto commitDto) {
            return View(commitDto);
        }

        public IActionResult CreatePost(CommitCreateDto commitDto) {
            // todo add name from its repository
            // validate and add to db
            return RedirectToAction("Create", commitDto);
        }
    }
}
