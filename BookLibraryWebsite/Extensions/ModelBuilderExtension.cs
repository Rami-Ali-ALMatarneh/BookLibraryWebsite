using BookLibraryWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookLibraryWebsite.Extensions
    {
    public static class ModelBuilderExtension
        {
        public static void setUniqueId( this ModelBuilder modelBuilder )
            {
            modelBuilder.Entity<AppUser>()
              .HasIndex(e => e.UserId).IsUnique();

            modelBuilder.HasSequence<int>("UniqueUserId");
            modelBuilder.Entity<AppUser>()
                .Property(e => e.UserId)
                .HasDefaultValueSql("NEXT VALUE FOR UniqueUserId");
            }
        public static void setFKBookAppUser( this ModelBuilder modelBuilder )
            {
            modelBuilder.Entity<Book>()
                 .HasOne(e => e.AppUser)
                 .WithMany(e => e.books)
                 .HasPrincipalKey(e => e.UserId)
                 .HasForeignKey(e => e.AppUserId);
            }
        public static void SeedBook( this ModelBuilder modelBuilder )
            {
            modelBuilder.Entity<Book>().HasData(new Book
                {
                Id = 1,
                Title = "Book 1",
                Description = "",
                Price = (float)0.0,
                discount = (float)0.0,
                Created = new DateTime(2023, 1, 1),
                author = "Rami Ali",
                KindOfBooks = KindOfBooks.Action_and_Adventure,
                photoPath = "",
                filePath = "",

                });
            modelBuilder.Entity<Book>().HasData(new Book
                {
                Id = 2,
                Title = "Book 2",
                Description = "",
                Price = (float)0.0,
                discount = (float)0.0,
                Created = new DateTime(2023, 1, 1),
                author = "Rami Ali",
                KindOfBooks = KindOfBooks.Action_and_Adventure,
                photoPath = "",
                filePath = "",

                });
            modelBuilder.Entity<Book>().HasData(new Book
                {

                Id = 3,
                Title = "Book 3",
                Description = "",
                Price = (float)0.0,
                discount = (float)0.0,
                Created = new DateTime(2023, 1, 1),
                author = "Rami Ali",
                KindOfBooks = KindOfBooks.Action_and_Adventure,
                photoPath = "",
                filePath = "",

                });
            modelBuilder.Entity<Book>().HasData(new Book
                {
                Id = 4,
                Title = "Book 4",
                Description = "",
                Price = (float)0.0,
                discount = (float)0.0,
                Created = new DateTime(2023, 1, 1),
                author = "Rami Ali",
                KindOfBooks = KindOfBooks.Action_and_Adventure,
                photoPath = "",
                filePath = ""

                });
            modelBuilder.Entity<Book>().HasData(new Book
                {

                Id = 5,
                Title = "Book 5",
                Description = "",
                Price = (float)0.0,
                discount = (float)0.0,
                Created = new DateTime(2023, 1, 1),
                author = "Rami Ali",
                KindOfBooks = KindOfBooks.Action_and_Adventure,
                photoPath = "",
                filePath = "",

                });
            modelBuilder.Entity<Book>().HasData(new Book
                {

                Id = 6,
                Title = "Book 6",
                Description = "",
                Price = (float)0.0,
                discount = (float)0.0,
                Created = new DateTime(2023, 1, 1),
                author = "Rami Ali",
                KindOfBooks = KindOfBooks.Action_and_Adventure,
                photoPath = "",
                filePath = "",
                });
            }
        public static void seedAlert( this ModelBuilder modelBuilder )
            {
            modelBuilder.Entity<Schedule>().HasData(new Schedule
                {
                Id = 1,
                Title = "Alert Test 1",
                start = new TimeSpan(
                   0, 0, 0
                    )
                ,
                end = new TimeSpan(0, 0, 0)

                });
            }
        }
    }
