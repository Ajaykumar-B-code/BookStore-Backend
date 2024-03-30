using CommonLayer.ResModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;

namespace BookStore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WishListController: ControllerBase
    {
        private readonly IWishListManager manager;
        public WishListController(IWishListManager manager)
        {
            this.manager = manager;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToWishList")]
        public ActionResult AddToWishlist(int BookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.AddToWishList(userId, BookId);
                if (response != null)
                {
                    return Ok(new ResModel<WishListEntity> { Success = true, Message = "Added to WishList", Data = response });
                }
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "Adding to WishList Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<WishListEntity> { Success=false,Message= ex.Message});
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveFromWishList")]
        public ActionResult RemoveFromWishList(int BookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.RemoveFromWishList(userId, BookId);
                if (response != null)
                {
                    return Ok(new ResModel<WishListEntity> { Success = true, Message = "Removed From WishList", Data = response });
                }
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "Removed From WishList Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = ex.Message });
            }
        }
    }
}
