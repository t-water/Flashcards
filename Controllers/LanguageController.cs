using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flashcards.Models;
using Flashcards.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Flashcards.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository languageRepository;
        private readonly ILanguageFamilyRepository languageFamilyRepository;

        public LanguageController(ILanguageRepository languageRepository, ILanguageFamilyRepository languageFamilyRepository)
        {
            this.languageRepository = languageRepository;
            this.languageFamilyRepository = languageFamilyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await languageRepository.GetLanguagesAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new Language();
            PopulateLanguageFamilyDropdownList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Language model)
        {
            if (ModelState.IsValid)
            {
                model.Abbreviation = model.Abbreviation.ToLower();
                model.EnglishName = CapitalizeFirstLetter(model.EnglishName);
                model.NativeName = CapitalizeFirstLetter(model.NativeName);

                await languageRepository.AddAsync(model);

                return RedirectToAction("index");
            }

            return View(model);
        }

        private string CapitalizeFirstLetter(string word)
        {
            if(word.Length == 1)
            {
                return word.ToUpper();
            }

            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }

        private void PopulateLanguageFamilyDropdownList(object selectedFamily = null)
        {
            var familiesQuery = languageFamilyRepository.GetLanguageFamiliesDropdownQuery();
            ViewBag.LanguageFamilyId = new SelectList(familiesQuery.AsNoTracking(), "LanguageFamilyId", "Name", selectedFamily);
        }
    }
}