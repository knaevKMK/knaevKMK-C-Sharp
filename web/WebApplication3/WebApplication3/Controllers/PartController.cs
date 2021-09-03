using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class PartController : Controller
    {

        private readonly IPartService partService;

        public PartController(IPartService partService)
        {
            this.partService = partService;
        }


        // GET: PartController
        public ActionResult Index()
        {

            return View();
        }

        // GET: PartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartController/Create
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

        // GET: PartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PartController/Edit/5
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

        // GET: PartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PartController/Delete/5
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
