using Flashcards.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Data
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly ApplicationDbContext context;

        public FlashcardRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Add(Flashcard model)
        {
            context.Flashcards.Add(model);

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

        public async Task<Flashcard> GetFlashcardAsync(int id)
        {
            return await context.Flashcards.Where(f => f.FlashcardId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Flashcard>> GetFlashcardsAsync()
        {
            return await context.Flashcards.Include(f => f.Language).ToListAsync();
        }
    }
}
