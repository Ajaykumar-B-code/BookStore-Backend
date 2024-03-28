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
            if (cart == null)
            {
                CartEntity newCart = new CartEntity();
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

        //public CartEntity RemoveFromCart(int Userid,int Bookid)
        //{
        //    CartEntity cart= context.AddToCartTable.FirstOrDefault(x=>x.UserId==Userid && x.BookId==Bookid);
        //    if(cart!=null)
        //    {
        //        if (cart.Quantity > 1)
        //        {
        //            cart.Quantity -= 1;
        //            context.SaveChanges();
        //            return cart;
        //        }
        //        else if(cart.Quantity == 1)
        //        {
        //            context.AddToCartTable.Remove(cart);
        //            context.SaveChanges();
        //        }
        //    }
        //    throw new Exception("Book is not in the cart to remove");
        //}

        
    }
}
   