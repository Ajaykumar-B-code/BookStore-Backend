﻿using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class WishListManager: IWishListManager
    {
        private readonly IWishListRepository repository;
        public WishListManager(IWishListRepository repository)
        {
            this.repository = repository;
        }
        public WishListEntity AddToWishList(int UserId, int BookId)
        {
            return repository.AddToWishList(UserId, BookId);
        }
        public WishListEntity RemoveFromWishList(int UserId, int BookId)
        {
            return repository.RemoveFromWishList(UserId, BookId);
        }
        public List<WishListEntity> GetAllWishListNotes(int UserId)
        {
            return repository.GetAllWishListNotes(UserId);
        }
    }
}
