namespace BookLibraryWebsite.Models
    {
    public class SqlBookRepository : IBookRepository
        {
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
