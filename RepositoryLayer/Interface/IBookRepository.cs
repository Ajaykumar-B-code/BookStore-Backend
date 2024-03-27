using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRepository
    {

        public BookEntity AddBook(AddBookModel model);

        //public BookEntity GetBookByName(string name);

        //public List<BookEntity> GetAllBook();
    }
}
