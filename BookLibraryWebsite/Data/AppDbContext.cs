using BookLibraryWebsite.Extensions;
using BookLibraryWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebsite.Data
    {
    public class AppDbContext : DbContext
        {
        public AppDbContext( DbContextOptions <AppDbContext> options ) : base(options)
            {
            }
        public DbSet<Book> Book { get; set; }
        protected override void OnModelCreating( ModelBuilder modelBuilder )
            {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedBook();
            }
        }
    }
