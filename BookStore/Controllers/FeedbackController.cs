
using CommonLayer.RequestModel;
using CommonLayer.ResModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;

namespace BookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController:ControllerBase
    {
        private readonly IFeedbackManager manager;
        private readonly BookStoreContext context;

        public FeedbackController(IFeedbackManager manager, BookStoreContext context)
        {
            this.manager = manager;
            this.context = context; 
        }


        [Route("AddFeedback")]
        [HttpPost]
        public ActionResult AddFeedback(int Bookid,AddFeedbackModel model)
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = manager.AddFeedback(userId,Bookid,model);
            if (response != null)
            {
                return Ok(new ResModel<FeedbackEntity> { Success=true,Message="Feedback Received successfully",Data= response });
            }
            return BadRequest(new ResModel<FeedbackEntity> { Success=false,Message="Feedback addition failed",Data=null});
        }
    }
}
