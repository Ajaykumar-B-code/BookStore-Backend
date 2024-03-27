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

        public BookEntity GetBookById(int id);

        public List<BookEntity> GetAllBook();

        public List<BookEntity> SortByPrice();
        public List<BookEntity> SortByPriceDESC();
        public List<BookEntity> Search(string query);

        public List<BookEntity> SortByArrivalASC();

    }
}









