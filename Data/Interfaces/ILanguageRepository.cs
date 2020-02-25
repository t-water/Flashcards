using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Data
{
    public interface ILanguageRepository
    {
        Task<Language> GetLanguageAsync(int id);
        Task<IEnumerable<Language>> GetLanguagesAsync();
        Task<bool> AddAsync(Language language);
        IOrderedQueryable<Language> GetLanguageDropdownQuery();
        /*    	Language Update(Language language);
                bool Delete(Language language); */
    }
}
