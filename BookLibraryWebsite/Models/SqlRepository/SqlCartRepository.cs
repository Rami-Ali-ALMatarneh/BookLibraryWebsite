using BookLibraryWebsite.Data;
using BookLibraryWebsite.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebsite.Models.SqlRepository
{
    public class SqlCartRepository : ICartRepository
    {
        private readonly AppDbContext _appDbContext;
        public SqlCartRepository(AppDbContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
        }
        public Cart AddCart(Cart cart)
        {
            _appDbContext.Cart.Add(cart);
            _appDbContext.SaveChanges();
            return cart;
        }

        public Cart deleteCart(int id)
        {
            var cart = _appDbContext.Cart.Find(id);
            if (cart != null)
            {
                _appDbContext.Cart.Remove(cart);
                _appDbContext.SaveChanges();
            }
            return cart;
        }

        public IEnumerable<Cart> getAllCart()
        {
            return _appDbContext.Cart;
        }

        public Cart getCartById(int id)
        {
            return _appDbContext.Cart.SingleOrDefault(e => e.BookId == id);
        }
    }
}
