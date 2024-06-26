﻿using CommonLayer.RequestModel;
using CommonLayer.ResModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager manager;
        private readonly BookStoreContext context;

        public BookController(IBookManager manager, BookStoreContext context)
        {
            this.manager = manager;
            this.context = context;
        }



        [HttpPost]
        [Route("Addbook")]
        public ActionResult AddBook(AddBookModel model)
        {
            var response = manager.AddBook(model);
            if (response != null)
            {
                return Ok(new ResModel<BookEntity> { Success = true, Message = "Book Added", Data = response });
            }
            return BadRequest(new ResModel<BookEntity> { Success = false, Message = "Book Adding failed", Data = null });
        }


        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            try
            {
                var response = manager.GetBookById(id);
                if (response != null)
                {
                    return Ok(new ResModel<BookEntity> { Success = true, Message = "Book Fetched", Data = response });
                }
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = "Book Fetching Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public ActionResult GetAllBooks()
        {
            var response = manager.GetAllBook();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Books Displayed", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Books Displayed Failed", Data = null });
        }

        [HttpGet]
        [Route("SortBypriceASC")]
        public ActionResult SortByPrice()
        {
            var response = manager.SortByPrice();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Notes Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Notes Sorting Failed", Data = null });
        }

        [HttpGet]
        [Route("SortBypriceDSC")]
        public ActionResult SortByPriceDesc()
        {
            var response = manager.SortByPriceDESC();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Notes Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Notes Sorting Failed", Data = null });
        }
        [HttpGet]
        [Route("GetbySearch")]
        public ActionResult GetbySearch(string query)
        {
            try
            {
                var response = manager.Search(query);
                if (response != null)
                {
                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Get search result succesfully", Data = response });
                }
                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success=false,Message=ex.Message});
            }
        }

        [HttpGet]
        [Route("sortByArrivalASC")]
        public ActionResult SortByArrivalASC()
        {
            var response = manager.SortByArrivalASC();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Notes Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Notes Sorting Failed", Data = null });
        }

        [HttpGet]
        [Route("sortByArrivalDSC")]
        public ActionResult SortByArrivalDSC()
        {
            var response = manager.SortByArrivalDSC();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Notes Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Notes Sorting Failed", Data = null });
        }
    }
}

