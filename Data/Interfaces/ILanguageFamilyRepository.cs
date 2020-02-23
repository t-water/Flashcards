using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Data
{
    public interface ILanguageFamilyRepository
    {
        Task<bool> CreateAsync(LanguageFamily model);
        Task<LanguageFamily> GetLanguageFamilyAsync(int id);
        Task<IEnumerable<LanguageFamily>> GetLanguageFamiliesAsync();
        IOrderedQueryable<LanguageFamily> GetLanguageFamiliesDropdownQuery();
    }
}
