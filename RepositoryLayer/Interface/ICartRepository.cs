using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRepository
    {
        public CartEntity AddToCart(int UserId, int BookId);

        //public CartEntity RemoveFromCart(int Userid, int Bookid);
    }
}
