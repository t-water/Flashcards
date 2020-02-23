using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Models;

namespace Flashcards.ViewModels
{
    public class BrowseLanguagesViewModel
    {
        public Language Language { get; set; }
        public bool IsLearning { get; set; }
    }
}
