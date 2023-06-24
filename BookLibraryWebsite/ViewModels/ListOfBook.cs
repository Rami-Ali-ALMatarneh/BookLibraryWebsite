using BookLibraryWebsite.Models;

namespace BookLibraryWebsite.ViewModels
    {
    public class ListOfBook
        {
        public IEnumerable<Book> Books { get; set; }
        public KindOfBooks KindOfBooks { get; set; }

        }
    }
