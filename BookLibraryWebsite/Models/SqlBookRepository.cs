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
            throw new NotImplementedException();
            }

        /***************************************************/

        Book IBookRepository.GetBook( string title )
            {
            throw new NotImplementedException();
            }

        /***************************************************/

        IEnumerable<Book> IBookRepository.GetBookByKindOfBooks( KindOfBooks books )
            {
            throw new NotImplementedException();
            }

        /***************************************************/

        Book IBookRepository.UpdateBook( Book book )
            {
            throw new NotImplementedException();
            }
        /***************************************************/
        }
    }
