﻿namespace BookLibraryWebsite.Models.Repository
{
    public interface ICartRepository
    {
        public Cart AddCart(Cart cart);
        public IEnumerable<Cart> getAllCart();
        public Cart deleteCart(int id);
        public Cart getCartById(int id);
        public IEnumerable<Cart> getAllByUserId(int userId);
        public void deleteAllCartByUserId(int userId);
    }
}
