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
        public UserEntity UserLogin(loginModel model)
        {
            return repository.UserLogin(model);
        }
    }
}
