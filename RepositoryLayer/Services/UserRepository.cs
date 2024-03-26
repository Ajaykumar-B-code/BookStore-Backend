using BCrypt.Net;
using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly BookStoreContext context;
        Encryption bcrypt = new Encryption();

        public UserRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public UserEntity UserRegistration(RegistrationModel model)
        {
            UserEntity entity = new UserEntity();
            var user = context.UserTable.FirstOrDefault(x=>x.EmailId == model.EmailId);
            if (user == null)
            {
                entity.FullName = model.FullName;
                entity.EmailId = model.EmailId;
                string encryptedPassword = bcrypt.HashGenerator(model.Password);
                entity.Password = encryptedPassword;
                entity.MobileNumber = model.MobileNumber;
                context.UserTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
            throw new Exception("User Already Exist");
        }

        public UserEntity UserLogin(loginModel model)
        {
            var user = context.UserTable.FirstOrDefault(x => x.EmailId == model.EmailId);

            if (user != null)
            {
                if (bcrypt.MatchPass(model.Password, user.Password))
                {
                    return user;
                }
                throw new Exception("Incorrect password");

            }
            throw new Exception("Incorrect email");
        }
    }
}
