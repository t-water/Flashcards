using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Flashcards.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Flashcards.Data;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class FlashcardController : Controller
    {
        private readonly ILanguageRepository languageRepository;

        public FlashcardController(ILanguageRepository languageRepository)
        {
            this.languageRepository = languageRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new Flashcard();
            PopulateLanguageDropdownList();
            return View(model);
        }

        private void PopulateLanguageDropdownList(object selectedFamily = null)
        {
            var familiesQuery = languageRepository.GetLanguageDropdownQuery();
            ViewBag.LanguageId = new SelectList(familiesQuery.AsNoTracking(), "LanguageId", "EnglishName", selectedFamily);
        }
    }
}