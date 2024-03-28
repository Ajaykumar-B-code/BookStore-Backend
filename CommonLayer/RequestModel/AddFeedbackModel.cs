using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class AddFeedbackModel
    {
        public int BookId { get; set; }

        public float CustomerRatings { get; set; }

        public string CustomerFeedback { get; set; }
    }
}
