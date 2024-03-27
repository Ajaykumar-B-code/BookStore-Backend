﻿using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRepository
    {

        public BookEntity AddBook(AddBookModel model);

        public BookEntity GetBookById(int id);

        public List<BookEntity> GetAllBook();

    }
}
