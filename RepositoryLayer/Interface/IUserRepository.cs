using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface  IUserRepository
    {
        public UserEntity UserRegistration(RegistrationModel model);

        public string UserLogin(loginModel model);

        public ForgotPasswordModel ForgetPassword(string email);

        public bool UserResetPassword(string Email, resetPasswordModel model);
    }
}
