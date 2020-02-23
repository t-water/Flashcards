using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Data;
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
    }
}