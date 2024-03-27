using CommonLayer.RequestModel;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class BookManager:IBookManager
    {
        private readonly IBookRepository repository;
        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }

        public BookEntity AddBook(AddBookModel model)
        {
            return repository.AddBook(model);
        }
        public BookEntity GetBookById(int id)
        {
            return repository.GetBookById(id);
        }

        public List<BookEntity> GetAllBook()
        {
            return repository.GetAllBook();
        }

        public List<BookEntity> SortByPrice()
        {
            return repository.SortByPrice();    
        }








    }
}
