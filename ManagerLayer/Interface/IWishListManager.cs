using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IWishListManager
    {
        public WishListEntity AddToWishList(int UserId, int BookId);

        public WishListEntity RemoveFromWishList(int UserId, int BookId);

        public List<WishListEntity> GetAllWishListNotes(int UserId);
    }
}
