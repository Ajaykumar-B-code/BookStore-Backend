using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IBookManager
    {

        public BookEntity AddBook(AddBookModel model);

        //public BookEntity GetBookByName(string name);

        //public List<BookEntity> GetAllBook();

    }
}
