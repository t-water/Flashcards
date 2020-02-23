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

        public bool IsLearning(string userId, int languageId)
        {
            return context.UserLanguages.Where(ul => ul.UserId == userId).Where(ul => ul.LanguageId == languageId).Any();
        }

        public async Task<bool> Add(UserLanguage model)
        {
            if (IsLearning(model.UserId, model.LanguageId))
            {
                return false;
            }
            else
            {
                context.UserLanguages.Add(model);

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
        }

        public async Task<UserLanguage> GetUserLanguage(string userId, int languageId)
        {
            return await context.UserLanguages.Where(ul => ul.UserId == userId)
                                              .Where(ul => ul.LanguageId == languageId)
                                              .Include(ul => ul.User)
                                              .Include(ul => ul.Language)
                                              .FirstOrDefaultAsync();
        }

        public async Task<bool> Delete(UserLanguage model)
        {
            context.UserLanguages.Remove(model);

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
    }
}
