using BookLibraryWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookLibraryWebsite.Extensions
    {
    public static class ModelBuilderExtension
        {
        public static void SeedBook(this ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Book>().HasData(new Book
                {
                Title = "Book 1",
                Description="",
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
                Title = "Book 2",
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
                Title = "Book 3",
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
                Title = "Book 5",
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
                Title = "Book 6",
                Description = "",
                Price = (float)0.0,
                discount = (float)0.0,
                Created = new DateTime(2023, 1, 1),
                author = "Rami Ali",
                KindOfBooks = KindOfBooks.Action_and_Adventure,
                photoPath = "",
                filePath=""
                });
            }
        }
    }
