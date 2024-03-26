using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class RegistrationModel
    {
        public String FullName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public string MobileNumber { get; set; }
    }
}
