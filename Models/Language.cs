using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    public class Language
    {
        public int LanguageId { get; set; }

        [Required]
        [Display(Name = "English Name")]
        public string EnglishName { get; set; }

        [Required]
        [Display(Name = "Native Name")]
        public string NativeName { get; set; }

        [Required]
        [MaxLength(5)]
        public string Abbreviation { get; set; }

        public int LanguageFamilyId { get; set; }
        public LanguageFamily LanguageFamily { get; set; }
    }
}
