using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Models;

namespace Flashcards.Data
{
    public interface IFlashcardRepository
    {
        Task<bool> Add(Flashcard model);
        Task<Flashcard> GetFlashcardAsync(int id);
        Task<IEnumerable<Flashcard>> GetFlashcardsAsync();
    }
}
