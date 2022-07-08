using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Domain.Models;
using SportWord.Core.Infraestructure.Repository.Abstract;
using Newtonsoft.Json;

namespace SportWord.Core.Application.UseCases
{
    public class AuthUseCase : IAuthUseCase
    {
        private readonly IAuthRepository<User, string> repository;
        public AuthUseCase (IAuthRepository< User, string> repository)
        {
            this.repository = repository;
        }

        public string Login(User user, string key)
        {
            var currentUser = repository.Login(user);
            if(currentUser == null)
            {
                return null;
            }
            var token = repository.GetToken(user, key);
            string result = JsonConvert.SerializeObject(new
            {
                token, 
                user = currentUser
            });
            return result;
        }
    }
}
