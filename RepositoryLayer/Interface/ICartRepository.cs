using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRepository
    {
        public CartEntity AddToCart(int UserId, int BookId);

        public CartEntity RemoveFromCart(int Userid, int Bookid);

        public CartEntity RemoveDirctly(int Userid, int Bookid);

        public List<CartEntity> GetAllCartItems(int userId);

        public List<CartEntity> PlaceOrder(int userId);

      //  public AddBookModel AddToCart2(int UserId, int BookId);
    }
}
