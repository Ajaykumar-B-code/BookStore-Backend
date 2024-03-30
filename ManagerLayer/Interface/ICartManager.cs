using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface ICartManager
    {
        public CartEntity AddToCart(int UserId, int BookId);

        public CartEntity RemoveFromCart(int Userid, int Bookid);

        public CartEntity RemoveDirctly(int Userid, int Bookid);

        public List<CartEntity> GetAll(int userId);

        public AddBookModel AddToCart2(int UserId, int BookId);
    }
}
