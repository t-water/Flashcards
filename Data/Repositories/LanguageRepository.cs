using Flashcards.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Data
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext context;

        public LanguageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Language> GetLanguageAsync(int id)
        {
            return await context.Languages.Where(lang => lang.LanguageId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await context.Languages.ToListAsync();
        }

        public async Task<bool> AddAsync(Language language){
            context.Languages.Add(language);
            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IOrderedQueryable<Language> GetLanguageDropdownQuery()
        {
            return from l in context.Languages orderby l.EnglishName select l;
        }
    }
}
