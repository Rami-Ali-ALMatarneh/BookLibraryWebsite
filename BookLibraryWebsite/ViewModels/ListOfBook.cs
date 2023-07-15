using BookLibraryWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.ViewModels
    {
    public class ListOfBook
        {
        public IEnumerable<Book> Books { get; set; }
        public Book book { get; set; }
        [Required]
        public KindOfBooks KindOfBooks { get; set; }
        public string TitleBook { get; set; }
        public IEnumerable<Schedule> scheduleTimes { get; set; }

        }
    }
