using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface ICartManager
    {
        public CartEntity AddToCart(int UserId, int BookId);

        //public CartEntity RemoveFromCart(int Userid, int Bookid);
    }
}
