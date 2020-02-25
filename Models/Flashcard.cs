using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Enums;

namespace Flashcards.Models
{
    public class Flashcard
    {
        public Flashcard()
        {
            Gender = null;
        }

        public int FlashcardId { get; set; }
        
        [Required]
        public string Word { get; set; }

        [Required]
        [Display(Name = "English Translation")]
        public string EnglishTranslation { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Part of Speech")]
        public PartsOfSpeech PartOfSpeech { get; set; }

        public Genders? Gender { get; set; }

        [Required]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
