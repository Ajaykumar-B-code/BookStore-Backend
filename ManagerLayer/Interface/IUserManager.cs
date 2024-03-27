using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IUserManager
    {
        public UserEntity UserRegistration(RegistrationModel model);

        public string UserLogin(loginModel model);

        public ForgotPasswordModel ForgetPassword(string email);

        public bool UserResetPassword(string Email, resetPasswordModel model);
    }

}
