using Flashcards.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Data
{
    public class UserLanguageRepository : IUserLanguageRepository
    {
        private readonly ApplicationDbContext context;

        public UserLanguageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<UserLanguage>> GetUserLanguagesByUserIdAsync(string id)
        {
            return await context.UserLanguages.Where(ul => ul.UserId == id).Include(ul => ul.Language).ToListAsync();
        }
    }
}
