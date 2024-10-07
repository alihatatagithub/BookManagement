using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> CheckUserPassword(string email, string password);
        Task<User> CheckUserToken(string userId, string refreshToken);
        Task<string> CreateUser(User user, string password);
        Task<string> UpdateUserToken(User user);
    }
}
