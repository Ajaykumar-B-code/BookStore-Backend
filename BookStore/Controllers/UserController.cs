using BCrypt.Net;
using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.ResModel;
using ManagerLayer.Interface;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserManager userManager;
        private readonly BookStoreContext context;
        private readonly IBus _bus;

        public UserController(IUserManager userManager, BookStoreContext context,IBus _bus)
        {
            this.userManager = userManager;
            this.context = context;
            this._bus = _bus;
        }

        [HttpPost]
        [Route("reg")]
        public ActionResult Register(RegistrationModel model)
        {
            try
            {
                var response = userManager.UserRegistration(model);
                if (response != null)
                {
                    return Ok(new ResModel<UserEntity> { Success = true, Message = "Registration SucessFull", Data = response });
                }
                return BadRequest(new ResModel<UserEntity> { Success = false, Message = "Registration Failed", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<UserEntity> { Success=false,Message = ex.Message});
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult login(loginModel model)
        {
            try
            {
                var response = userManager.UserLogin(model);
                if(response != null)
                {
                    return Ok(new ResModel<string> { Success = true, Message = "Login Sucessfull", Data = response });
                }
                return BadRequest(new ResModel<string> { Success = false, Message = "Login Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string>{ Success = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string Email)
        {

            send mail = new send();
            ForgotPasswordModel model = userManager.ForgetPassword(Email);
            var checkmail = context.UserTable.FirstOrDefault(x => x.EmailId == Email); 
            if (checkmail != null)
            {
                mail.SendMail(Email, model.Token);
                Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(model);
                return Ok(new ResModel<String> { Success = true, Message = "Mail sent", Data = model.Token });
     
     
            }
            else
            {
                return BadRequest(new ResModel<String> { Success = false, Message = "not found", Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Reset")]
        public ActionResult ForgetPassword(resetPasswordModel model)
        {
            try
            {
                string email = User.FindFirst("Email").Value;
                if (userManager.UserResetPassword(email, model))
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Password Changed", Data = true });
                }
                return BadRequest(new ResModel<bool> { Success = false, Message = "Password not changed", Data = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, });
            }
        }

    }
}
