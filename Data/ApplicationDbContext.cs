﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Flashcards.Models;

namespace Flashcards.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageFamily> LanguageFamilies { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
    }
}
