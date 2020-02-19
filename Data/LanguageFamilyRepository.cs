using Flashcards.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Data
{
    public class LanguageFamilyRepository : ILanguageFamilyRepository
    {
        private readonly ApplicationDbContext context;

        public LanguageFamilyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(LanguageFamily model)
        {
            context.LanguageFamilies.Add(model);
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

        public async Task<LanguageFamily> GetLanguageFamilyAsync(int id)
        {
            return await context.LanguageFamilies.Where(l => l.LanguageFamilyId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LanguageFamily>> GetLanguageFamiliesAsync()
        {
            return await context.LanguageFamilies.ToListAsync();
        }
    }
}
