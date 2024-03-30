using CommonLayer.RequestModel;
using CommonLayer.ResModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager manager;
        private readonly BookStoreContext context;
        public CartController(ICartManager manager, BookStoreContext context)
        {
            this.manager = manager;
            this.context = context;
        }
        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public ActionResult AddToCart(int Bookid)
        {
            try
            {
                int UserId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.AddToCart(UserId, Bookid);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Cart updated", Data = response });
                }
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Cart updation is failed", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message });
            }
        }
        [Authorize]
        [HttpPut]
        [Route("RemoveFromCart")]
        public ActionResult RemoveFromCart(int Bookid)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.RemoveFromCart(userId, Bookid);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Cart Update", Data = response });
                }
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Cart updation is failed", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveDirectly")]
        public ActionResult RemoveDirectly(int Bookid)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.RemoveDirctly(userId, Bookid);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Cart is removed ", Data = response });
                }
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Cart removal is failed", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllbooksInCart")]

        public ActionResult GetAllBooksInCart()
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = manager.GetAll(userId);
            if (response != null)
            {
                return Ok(new ResModel<List<CartEntity>> { Success=true,Message="items in the cart are fetched",Data=response});
            }
            return BadRequest(new ResModel<List<CartEntity>> { Success=true,Message="fetching of books in cart failed",Data = response});
        }

        [Authorize]
        [HttpPost]
        [Route("AddToCart2")]
        public ActionResult AddToCart2(int Bookid)
        {
            try
            {
                int UserId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.AddToCart2(UserId, Bookid);
                if (response != null)
                {
                    return Ok(new ResModel<AddBookModel> { Success = true, Message = "Cart updated", Data = response });
                }
                return BadRequest(new ResModel<AddBookModel> { Success = false, Message = "Cart updation is failed", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<AddBookModel> { Success = false, Message = ex.Message });
            }
        }


    }
}
