using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    public class LanguageFamily
    {
        public int LanguageFamilyId { get; set; }
        public string Name { get; set; }
        public ICollection<Language> Languages { get; set; }
    }
}
