using BookLibraryWebsite.Extensions;
using BookLibraryWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebsite.Data
    {
    public class AppDbContext : IdentityDbContext<AppUser> 
        {
        public AppDbContext( DbContextOptions <AppDbContext> options ) : base(options)
            {
            }
        public DbSet<Book> Book { get; set; }
        public DbSet<Schedule> Schedule { get; set; }   
        protected override void OnModelCreating( ModelBuilder modelBuilder )
            {
            base.OnModelCreating(modelBuilder);
            modelBuilder.setUniqueId();
            modelBuilder.setFKBookAppUser();
            modelBuilder.setFK_Schedule();
               // modelBuilder.SeedBook();
               //  modelBuilder.seedAlert();
            }
        }
    }
