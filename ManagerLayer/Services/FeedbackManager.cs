using CommonLayer.RequestModel;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class FeedbackManager:IFeedbackManager
    {

        private readonly IFeedbackRepository repository;

        public FeedbackManager(IFeedbackRepository repository)
        {
            this.repository= repository;
        }
        public FeedbackEntity AddFeedback(int UserId, int bookId, AddFeedbackModel model)
        {
            return repository.AddFeedback(UserId, bookId, model);
        }
    }
}
