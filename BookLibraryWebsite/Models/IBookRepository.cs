using System.Collections;

namespace BookLibraryWebsite.Models
    {
    public interface IBookRepository
        {
        public Book GetBook( int id );
        public IEnumerable<Book> GetBookByKindOfBooks( KindOfBooks books );
        public IEnumerable<Book> getAllBooks();
        public Book AddBook( Book book );
        public Book UpdateBook( Book book );
        public Book DeleteBook( int id );
        public IEnumerable<Book> GetBooksByUserId(int id);
        public IEnumerable<Book> GetAllBooksByTitle( string title );
        }
    }
