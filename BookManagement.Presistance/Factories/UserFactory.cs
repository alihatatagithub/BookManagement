using BookManagement.Contracts.Factories;
using BookManagement.Data.DTO;
using BookManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Presistance.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(RegisterDTO model, string refreshToken)
        {
            return new User
            {
                Email = model.Email,
                UserName = model.Email,
                RefreshToken = refreshToken,
                RefreshTokenExpireDate = DateTime.Now.AddHours(1)
                
            };
        }
    }
}
