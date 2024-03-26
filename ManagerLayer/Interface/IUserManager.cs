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

        public UserEntity UserLogin(loginModel model);
    }
}
