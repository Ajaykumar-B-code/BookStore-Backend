﻿using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRepository: IBookRepository
    {
        public readonly BookStoreContext Context;
        
        public BookRepository(BookStoreContext context)
        {
            this.Context = context;
        }

        public BookEntity AddBook(AddBookModel model)
        {
            BookEntity book = new BookEntity();
            book.BookName = model.BookName;
            book.Author = model.Author;
            book.BookDescription= model.BookDescription;
            book.BookQuantity = model.BookQuantity;
            book.price = model.price;
            book.DiscountPrice = model.DiscountPrice;
            Context.Add(book);
            Context.SaveChanges();
            return book;
        }
    }
}