using BookLibraryWebsite.Data;
using BookLibraryWebsite.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebsite.Models.SqlRepository
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public SqlBookRepository(AppDbContext _context)
        {
            this._context = _context;

        }
        public Book AddBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
            return book;
        }

        /***************************************************/

        public Book DeleteBook(int id)
        {
            var book = _context.Book.Find(id);
            if (book != null)
            {
                _context.Book.Remove(book);
                _context.SaveChanges();
            }
            return book;

        }

        public IEnumerable<Book> GetAllBooksByTitle(string title)
        {
            var books = _context.Book.Where(e => e.Title == title);
            return books;
        }

        public IEnumerable<Book> GetBooksByUserId(int id)
        {
            var books = _context.Book.Where(e => e.AppUserId == id);
            return books;
        }

        /***************************************************/

        IEnumerable<Book> IBookRepository.getAllBooks()
        {
            return _context.Book;
        }

        /***************************************************/

        Book IBookRepository.GetBook(int id)
        {
            return _context.Book.Find(id);
        }

        /***************************************************/

        IEnumerable<Book> IBookRepository.GetBookByKindOfBooks(KindOfBooks books)
        {
            return _context.Book.Where(b => b.KindOfBooks == books);
        }
        /***************************************************/
        Book IBookRepository.UpdateBook(Book book)
        {
            var Books = _context.Book.Attach(book);
            Books.State = EntityState.Modified;
            _context.SaveChanges();
            return book;
        }
        /***************************************************/
    }
}
