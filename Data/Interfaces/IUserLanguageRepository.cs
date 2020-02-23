using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Data
{
    public interface IUserLanguageRepository
    {
        Task<IEnumerable<UserLanguage>> GetUserLanguagesByUserIdAsync(string id);
    }
}
