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

        public UserEntity UserLogin(loginModel model);

    }
}
