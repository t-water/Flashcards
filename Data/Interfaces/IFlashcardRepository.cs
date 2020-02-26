using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Models;

namespace Flashcards.Data
{
    public interface IFlashcardRepository
    {
        Task Add(Flashcard model);
        Task Update(Flashcard model);
        Task<Flashcard> GetFlashcardAsync(int id);
        Task<IEnumerable<Flashcard>> GetFlashcardsAsync();
    }
}
