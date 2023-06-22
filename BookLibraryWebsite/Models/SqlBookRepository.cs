using BookLibraryWebsite.Data;

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
            throw new NotImplementedException();
            }

        /***************************************************/

        Book IBookRepository.DeleteBook( Book book )
            {
            throw new NotImplementedException();
            }

        /***************************************************/

        IEnumerable<Book> IBookRepository.getAllBooks()
            {
            return _context.Book;
            }

        /***************************************************/

        Book IBookRepository.GetBook( string title )
            {
                return _context.Book.Find(title);
      
            }

        /***************************************************/

        IEnumerable<Book> IBookRepository.GetBookByKindOfBooks( KindOfBooks books )
            {
            return _context.Book.Where(b =>b.KindOfBooks == books ) ;
            }

        /***************************************************/

        Book IBookRepository.UpdateBook( Book book )
            {
            throw new NotImplementedException();
            }
        /***************************************************/
        }
    }
