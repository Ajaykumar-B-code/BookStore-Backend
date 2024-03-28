using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRepository
    {
        public FeedbackEntity AddFeedback(int UserId, int bookId, AddFeedbackModel model);
    }
}
