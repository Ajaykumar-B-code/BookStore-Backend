using CommonLayer.RequestModel;
using Microsoft.AspNetCore.Mvc.Formatters;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CartRepository: ICartRepository
    {
        private readonly BookStoreContext context;
        public CartRepository(BookStoreContext context)
        {
            this.context = context;
        }
        public CartEntity AddToCart(int UserId, int BookId)
        {
            CartEntity cart = context.AddToCartTable.FirstOrDefault(x => (x.UserId == UserId) && (x.BookId == BookId));
            BookEntity book = context.BookTable.FirstOrDefault(x=>(x.BookId==BookId));
            AddBookModel model = new AddBookModel();
            if (cart == null)
            {
                CartEntity newCart = new CartEntity();
                model.Author = book.Author;
                model.price = book.price;
                newCart.UserId = UserId;
                newCart.BookId = BookId;
                newCart.Quantity = 1;
                context.AddToCartTable.Add(newCart);
                context.SaveChanges();
                return newCart;
            }
            else
            {
                if (cart.Quantity <= 10)
                {
                    cart.Quantity += 1;
                    context.SaveChanges();
                    return cart;
                }
                throw new Exception("Add to Cart limit Exceeded!");
            }
        }

        public CartEntity RemoveFromCart(int Userid, int Bookid)
        {
            CartEntity cart = context.AddToCartTable.FirstOrDefault(x => x.UserId == Userid && x.BookId == Bookid);
            if (cart != null)
            {
                if (cart.Quantity > 1)
                {
                    cart.Quantity -= 1;
                    context.SaveChanges();
                    return cart;
                }
                else if (cart.Quantity == 1)
                {
                    context.AddToCartTable.Remove(cart);
                    context.SaveChanges();
                }
            }
            throw new Exception("Book is not in the cart to remove");
        }
        
        public CartEntity RemoveDirctly(int Userid, int Bookid)
        {
            CartEntity cart = context.AddToCartTable.FirstOrDefault(x => x.UserId == Userid && x.BookId == Bookid);
            if (cart != null)
            {
                context.AddToCartTable.Remove(cart);
                context.SaveChanges();
                return cart;
            }
            throw new Exception("Book is not there to remove directly");

        }
        public List<CartEntity> GetAll(int userId)
        {
            List<CartEntity> list = context.AddToCartTable.Where(x=>x.UserId == userId).ToList();
            return list;
        }

        public AddBookModel AddToCart2(int UserId, int BookId)
        {
            CartEntity cart = context.AddToCartTable.FirstOrDefault(x => (x.UserId == UserId) && (x.BookId == BookId));
            BookEntity book = context.BookTable.FirstOrDefault(x => (x.BookId == BookId));
            AddBookModel model = new AddBookModel();
            if (cart == null)
            {
                CartEntity newCart = new CartEntity();
                model.Author = book.Author;
                model.price = book.price;
                newCart.UserId = UserId;
                newCart.BookId = BookId;
                newCart.Quantity = 1;
                context.AddToCartTable.Add(newCart);
                context.SaveChanges();
                return model;
            }
            else
            {
                if (cart.Quantity <= 10)
                {
                    cart.Quantity += 1;
                    context.SaveChanges();
                    return model;
                }
                throw new Exception("Add to Cart limit Exceeded!");
            }
        }

    }


}
   