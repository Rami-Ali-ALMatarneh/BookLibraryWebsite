using BookLibraryWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebsite.Models
    {
    public class SqlBookRepository : IBookRepository
        {
        private readonly AppDbContext _context;
        public SqlBookRepository( AppDbContext _context )
            {
            this._context = _context;

            }
        Book IBookRepository.AddBook( Book book )
            {
            _context.Book.Add(book);
            _context.SaveChanges();
            return book;
            }

        /***************************************************/

        Book IBookRepository.DeleteBook( int id )
            {
            var book = _context.Book.Find(id);
            if (book != null)
                {
                _context.Book.Remove(book);
                _context.SaveChanges();
                }
            return book;

            }

        /***************************************************/

        IEnumerable<Book> IBookRepository.getAllBooks()
            {
            return _context.Book;
            }

        /***************************************************/

        Book IBookRepository.GetBook( int id )
            {
            return _context.Book.Find(id);
            }

        /***************************************************/

        IEnumerable<Book> IBookRepository.GetBookByKindOfBooks( KindOfBooks books )
            {
            return _context.Book.Where(b => b.KindOfBooks == books);
            }
        /***************************************************/
        Book IBookRepository.UpdateBook( Book book )
            {
            var Books = _context.Book.Attach(book);
            Books.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return book;
            }
        /***************************************************/
        }
    }
