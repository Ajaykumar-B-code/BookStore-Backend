using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishListRepository: IWishListRepository
    {
        private readonly BookStoreContext context;
        public WishListRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public WishListEntity AddToWishList(int UserId,int BookId)
        {
            var existingbook = context.WishListTable.FirstOrDefault(x=>x.UserId==UserId && x.BookId==BookId);
            if (existingbook == null)
            {
                WishListEntity newbook = new WishListEntity();
                newbook.UserId= UserId;
                newbook.BookId= BookId;
                context.WishListTable.Add(newbook);
                context.SaveChanges();
                return newbook;
            }
            throw new Exception("Book Already exist in the wishList");
        }

        public WishListEntity RemoveFromWishList(int UserId, int BookId)
        {
            var existingbook = context.WishListTable.FirstOrDefault(x => x.UserId == UserId && x.BookId == BookId);
            if (existingbook != null)
            {
                context.WishListTable.Remove(existingbook);
                context.SaveChanges() ;
                return existingbook;
            }
            throw new Exception("Book doesnot present in the wishList");
        }
        
        public List<WishListEntity> GetAllWishListNotes(int UserId)
        {
            List<WishListEntity> wishlist = context.WishListTable.Where(x => x.UserId == UserId).ToList();
            return wishlist;
        }
    }
}
