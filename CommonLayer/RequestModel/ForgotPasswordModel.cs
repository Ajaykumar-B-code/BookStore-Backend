using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class ForgotPasswordModel
    {
        public string EmailId { get; set; }

        public int UserId { get; set; }

        public string Token { get; set; } 
    }
}
