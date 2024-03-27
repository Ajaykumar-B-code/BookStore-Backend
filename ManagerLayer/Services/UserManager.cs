using CommonLayer.RequestModel;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public UserEntity UserRegistration(RegistrationModel model)
        {
            return repository.UserRegistration(model);
        }
        public string UserLogin(loginModel model)
        {
            return repository.UserLogin(model);
        }
        public ForgotPasswordModel ForgetPassword(string email)
        {
            return repository.ForgetPassword(email); 
        }

        public bool UserResetPassword(string Email, resetPasswordModel model)
        {
            return repository.UserResetPassword(Email, model);
        }
    }
}
