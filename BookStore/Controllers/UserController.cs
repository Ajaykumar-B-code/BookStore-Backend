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
    public class UserController : ControllerBase
    {

        private readonly IUserManager userManager;
        private readonly BookStoreContext context;

        public UserController(IUserManager userManager, BookStoreContext context)
        {
            this.userManager = userManager;
            this.context = context;
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
                    return Ok(new ResModel<UserEntity> { Success = true, Message = "Login Sucessfull", Data = response });
                }
                return BadRequest(new ResModel<UserEntity> { Success = false, Message = "Login Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<UserEntity>{ Success = false, Message = ex.Message });
            }
        }

    }
}
