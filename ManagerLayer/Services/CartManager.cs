using CommonLayer.RequestModel;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class CartManager: ICartManager
    {
        private readonly ICartRepository repository;
        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }
        public CartEntity AddToCart(int UserId, int BookId)
        {
            return repository.AddToCart(UserId, BookId);
        }

        public CartEntity RemoveFromCart(int Userid, int Bookid)
        {
            return repository.RemoveFromCart(Userid, Bookid);
        }

        public CartEntity RemoveDirctly(int Userid, int Bookid)
        {
            return repository.RemoveDirctly(Userid, Bookid);
        }
        public List<CartEntity> GetAllCartItems(int userId)
        {
            return repository.GetAllCartItems(userId);
        }

        public List<CartEntity> PlaceOrder(int userId)
        {
            return repository.PlaceOrder(userId);
        }
        //public AddBookModel AddToCart2(int UserId, int BookId)
        //{
        //    return repository.AddToCart2(UserId, BookId);
        //}
    }
}
