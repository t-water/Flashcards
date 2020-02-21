using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    public class UserLanguage
    {
        public UserLanguage()
        {
            WordStreakStart = DateTime.Now;
            DayStreak = 1;
            WordStreak = 0;
            Points = 0;
        }

        public int UserLanguageId { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        [Display(Name = "Streak")]
        public int DayStreak { get; set; }

        [Display(Name = "Word Streak")]
        public int WordStreak { get; set; }
        
        public DateTime WordStreakStart { get; set; }

        public int Points { get; set; }
    }
}
