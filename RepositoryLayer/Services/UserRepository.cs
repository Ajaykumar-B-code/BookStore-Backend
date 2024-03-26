using BCrypt.Net;
using CommonLayer.RequestModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly BookStoreContext context;
        private readonly IConfiguration config;
        Encryption bcrypt = new Encryption();

        public UserRepository(BookStoreContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
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

        public string GenerateToken(string Email, int Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",Email),
                new Claim("UserId",Id.ToString())
        };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(500),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string UserLogin(loginModel model)
        {
            var user = context.UserTable.FirstOrDefault(x => x.EmailId == model.EmailId);

            if (user != null)
            {
                if (bcrypt.MatchPass(model.Password, user.Password))
                {
                    string token = GenerateToken(user.EmailId, user.UserId);
                    return token;
                }
                throw new Exception("Incorrect password");

            }
            throw new Exception("Incorrect email");
        }

        public ForgotPasswordModel ForgetPassword(string email)
        {
            var user = context.UserTable.FirstOrDefault(x => x.EmailId == email);
            if (user != null)
            {
                ForgotPasswordModel forgotPassword = new ForgotPasswordModel();
                forgotPassword.EmailId = email;
                forgotPassword.UserId = user.UserId;
                forgotPassword.Token = GenerateToken(email,user.UserId);
                return forgotPassword;
            }
            else
            {   
                throw new Exception();
            }
        }
    }
}
