namespace BookLibraryWebsite.Models
    {
    public interface ICartRepository
        {
        public Cart AddCart( Cart cart );
        public IEnumerable<Cart> getAllCart();
        public Cart deleteCart( int id );
        public Cart getCartById( int id );
        }
    }
