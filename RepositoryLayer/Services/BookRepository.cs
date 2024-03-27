using CommonLayer.RequestModel;
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
            book.CreatedAt= DateTime.Now;
            Context.Add(book);
            Context.SaveChanges();
            return book;
        }

        public BookEntity GetBookById(int id)
        {
            BookEntity book = Context.BookTable.FirstOrDefault(x => x.BookId == id);
            if (book != null)
            {
                return book;
            }
            throw new Exception("Book Not found");
        }

        public List<BookEntity> GetAllBook()
        {
            return Context.BookTable.ToList();
        }

        public List<BookEntity> SortByPrice()
        {
            return Context.BookTable.OrderBy(x=>x.DiscountPrice).ToList();
        }

        public List<BookEntity> SortByPriceDESC()
        {
            return Context.BookTable.OrderByDescending(x => x.DiscountPrice).ToList();
        }

        public List<BookEntity> Search(string query)
        {
            List<BookEntity> response= Context.BookTable.Where(x=>(x.BookName==query)||(x.Author==query)).ToList();
            if (response.Count > 0)
            {
                return response;
            }
            throw new Exception("No books Found");
        }

        public List<BookEntity> SortByArrivalASC()
        {
            return Context.BookTable.OrderBy(x => x.CreatedAt).ToList();
        }

        public List<BookEntity> SortByArrivalDSC()
        {
            return Context.BookTable.OrderByDescending(x => x.CreatedAt).ToList();
        }


    }
}
