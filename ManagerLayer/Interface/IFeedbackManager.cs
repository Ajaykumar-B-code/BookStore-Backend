using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IFeedbackManager
    {
        public FeedbackEntity AddFeedback(int UserId, int bookId, AddFeedbackModel model);
    }
}
