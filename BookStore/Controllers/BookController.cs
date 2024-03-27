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
            if(response != null) 
            { 
                return Ok(new ResModel<BookEntity> { Success=true,Message="Book Added",Data = response });
            }
            return BadRequest(new ResModel<BookEntity> { Success = false, Message = "Book Adding failed", Data = null });
        }

        

    }
}
