using EmployeeManagement.Contracts.Factories;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Factories
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
        public void UpdateUserToken(User user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireDate = DateTime.Now.AddHours(1);
        }
    }
}
