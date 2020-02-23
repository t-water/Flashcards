using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Data;
using Flashcards.Models;
using Flashcards.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ILanguageRepository languageRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserLanguageRepository userLanguageRepository;

        public BrowseController(ILanguageRepository languageRepository,
                                UserManager<IdentityUser> userManager,
                                IUserLanguageRepository userLanguageRepository)
        {
            this.languageRepository = languageRepository;
            this.userManager = userManager;
            this.userLanguageRepository = userLanguageRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Languages()
        {
            var languages = await languageRepository.GetLanguagesAsync();
            languages = languages.OrderBy(l => l.EnglishName);

            var user = await userManager.GetUserAsync(HttpContext.User);

            var userLanguages = await userLanguageRepository.GetUserLanguagesByUserIdAsync(user.Id);
            var justLanguages = userLanguages.Select(ul => ul.Language);

            var model = new List<BrowseLanguagesViewModel>();

            foreach(var lang in languages)
            {
                var vm = new BrowseLanguagesViewModel
                {
                    Language = lang
                };

                if (justLanguages.Contains(lang))
                {
                    vm.IsLearning = true;
                }
                else
                {
                    vm.IsLearning = false;
                }

                model.Add(vm);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Language(int id)
        {
            var language = await languageRepository.GetLanguageAsync(id);

            if(language == null)
            {
                return NotFound();
            }

            var user = await userManager.GetUserAsync(HttpContext.User);

            var isLearning = userLanguageRepository.IsLearning(user.Id, language.LanguageId);

            var model = new BrowseLanguagesViewModel
            {
                Language = language,
                IsLearning = isLearning
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BeginLearning(int id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if(userLanguageRepository.IsLearning(user.Id, id))
            {
                return RedirectToAction("AlreadyLearning");
            }

            var model = new UserLanguage
            {
                UserId = user.Id,
                LanguageId = id
            };

            var result = await userLanguageRepository.Add(model);

            if (result)
            {
                return RedirectToAction("Languages");
            }
            else
            {
                return RedirectToAction("AlreadyLearning");
            }
        }

        [HttpGet]
        public async Task<IActionResult> StopLearning(int id)
        {
            var language = await languageRepository.GetLanguageAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            var user = await userManager.GetUserAsync(HttpContext.User);

            var model = await userLanguageRepository.GetUserLanguage(user.Id, language.LanguageId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StopLearning(UserLanguage model)
        {
            await userLanguageRepository.Delete(model);

            return RedirectToAction("languages");
        }
    }
}