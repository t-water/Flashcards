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
using Flashcards.Enums;

namespace Flashcards.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class FlashcardController : Controller
    {
        private readonly ILanguageRepository languageRepository;
        private readonly IFlashcardRepository flashcardRepository;

        public FlashcardController(ILanguageRepository languageRepository,
                                   IFlashcardRepository flashcardRepository)
        {
            this.languageRepository = languageRepository;
            this.flashcardRepository = flashcardRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await flashcardRepository.GetFlashcardsAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new Flashcard();
            PopulateLanguageDropdownList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Flashcard model)
        {
            if (ModelState.IsValid)
            {
                await flashcardRepository.Add(model);
                return RedirectToAction("index");
            }

            PopulateLanguageDropdownList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await flashcardRepository.GetFlashcardAsync(id);

            if(model == null)
            {
                return NotFound();
            }

            PopulateLanguageDropdownList(model.LanguageId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Flashcard model)
        {   
            if(id != model.FlashcardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await flashcardRepository.Update(model);
                return RedirectToAction("index");
            }

            PopulateLanguageDropdownList(model.LanguageId);
            return View(model);
        }

        private void PopulateLanguageDropdownList(object selectedLanguage = null)
        {
            var languageQuery = languageRepository.GetLanguageDropdownQuery();
            ViewBag.LanguageId = new SelectList(languageQuery.AsNoTracking(), "LanguageId", "EnglishName", selectedLanguage);
        }
    }
}