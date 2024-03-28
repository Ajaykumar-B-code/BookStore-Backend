using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class FeedbackRepository:IFeedbackRepository
    {
        private readonly BookStoreContext context;

        public FeedbackRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public FeedbackEntity AddFeedback(int UserId,int bookId,AddFeedbackModel model)
        {
            FeedbackEntity entity = new FeedbackEntity();
            entity.CustomerRatings = model.CustomerRatings;
            entity.CustomerFeedback = model.CustomerFeedback;
            entity.BookId=bookId;
            entity.UserId = UserId;
            context.Add(entity);
            context.SaveChanges();
            return entity;

        }
    }
}
