using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer
{
    public class send
    {
        //public string SendMail(string ToEmail, string Token)
        //{
        //    string FromEmail = "bonagiriajaykumar1@gmail.com";
        //    MailMessage Message = new MailMessage(FromEmail, ToEmail);
        //    string MailBody ="Token for reset password"+Token;
        //    Message.Subject = "Token Generated for resetting password";
        //    Message.Body = MailBody.ToString();
        //    Message.BodyEncoding = Encoding.UTF8;
        //    Message.IsBodyHtml = true;

        //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        //    NetworkCredential credential = new NetworkCredential("bonagiriajaykumar1@gmail.com", "zqni yvsb sfxl wbgg");

        //    smtpClient.EnableSsl = true;
        //    smtpClient.UseDefaultCredentials = true;
        //    smtpClient.Credentials = credential;

        //    smtpClient.Send(Message);
        //    return ToEmail;
        //}

    }
}
