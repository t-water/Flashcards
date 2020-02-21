using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Data;
using Flashcards.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LanguageFamilyController : Controller
    {
        private readonly ILanguageFamilyRepository languageFamilyRepository;

        public LanguageFamilyController(ILanguageFamilyRepository languageFamilyRepository)
        {
            this.languageFamilyRepository = languageFamilyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await languageFamilyRepository.GetLanguageFamiliesAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new LanguageFamily();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageFamily model)
        {
            if (ModelState.IsValid)
            {
                await languageFamilyRepository.CreateAsync(model);
                return RedirectToAction("index");
            }

            return View(model);
        }
    }
}